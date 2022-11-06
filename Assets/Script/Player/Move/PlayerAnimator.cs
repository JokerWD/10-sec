using UnityEngine;
using Random = UnityEngine.Random;

namespace TenSeconds {
    public class PlayerAnimator : MonoBehaviour {
        [SerializeField] private Animator anim;
        [SerializeField] private AudioSource source;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private ParticleSystem jumpParticles, launchParticles;
        [SerializeField] private ParticleSystem moveParticles, landParticles;
        [SerializeField] private AudioClip[] footsteps;
        [SerializeField] private float maxTilt = .1f;
        [SerializeField] private float tiltSpeed = 1;
        [SerializeField, Range(1f, 3f)] private float maxIdleSpeed = 2;
        [SerializeField] private float maxParticleFallSpeed = -40;

        private IPlayerController _player;
        private bool _playerGrounded;
        private ParticleSystem.MinMaxGradient _currentGradient;
        private Vector2 _movement;

        void Awake() => _player = GetComponentInParent<IPlayerController>();

        void Update() {
            if (_player == null) return;

            if (_player.Input.X != 0) {
                anim.SetFloat(SpeedKey, Mathf.Abs(_player.RawMovement.x));
            }
            else{
                anim.SetFloat(SpeedKey, 0);
            }

            if (_player.Input.X != 0) transform.localScale = new Vector3(_player.Input.X > 0 ? 1 : -1, 1, 1);

            var targetRotVector = new Vector3(0, 0, Mathf.Lerp(-maxTilt, maxTilt, Mathf.InverseLerp(-1, 1, _player.Input.X)));
            anim.transform.rotation = Quaternion.RotateTowards(anim.transform.rotation, Quaternion.Euler(targetRotVector), tiltSpeed * Time.deltaTime);

            anim.SetFloat(IdleSpeedKey, Mathf.Lerp(1, maxIdleSpeed, Mathf.Abs(_player.Input.X)));

            if (_player.LandingThisFrame) {
                anim.SetTrigger(GroundedKey);
                source.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
            }

            if (_player.JumpingThisFrame) {
                anim.SetTrigger(JumpKey);
                anim.ResetTrigger(GroundedKey);

                if (_player.Grounded) {
                    SetColor(jumpParticles);
                    SetColor(launchParticles);
                    jumpParticles.Play();
                }
            }

            if (!_playerGrounded && _player.Grounded) {
                _playerGrounded = true;
                moveParticles.Play();
                landParticles.transform.localScale = Vector3.one * Mathf.InverseLerp(0, maxParticleFallSpeed, _movement.y);
                SetColor(landParticles);
                landParticles.Play();
            }
            else if (_playerGrounded && !_player.Grounded) {
                _playerGrounded = false;
                moveParticles.Stop();
            }

            var groundHit = Physics2D.Raycast(transform.position, Vector3.down, 2, groundMask);
            if (groundHit && groundHit.transform.TryGetComponent(out SpriteRenderer r)) {
                _currentGradient = new ParticleSystem.MinMaxGradient(r.color * 0.9f, r.color * 1.2f);
                SetColor(moveParticles);
            }

            _movement = _player.RawMovement; 
            
        }

        private void OnDisable() {
            moveParticles.Stop();
        }

        private void OnEnable() {
            moveParticles.Play();
        }

        void SetColor(ParticleSystem ps) {
            var main = ps.main;
            main.startColor = _currentGradient;
        }

        #region Animation Keys

        private static readonly int GroundedKey = Animator.StringToHash("Grounded");
        private static readonly int IdleSpeedKey = Animator.StringToHash("IdleSpeed");
        private static readonly int JumpKey = Animator.StringToHash("Jump");
        private static readonly int SpeedKey = Animator.StringToHash("Speed");

        #endregion
    }
}