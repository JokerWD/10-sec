using System.Collections;
using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bulletRigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private int _timeToDeath;
        
        private Player _player;
        private Transform _bullet;
        
        #region Zenject

       // [Inject]
      //  private void Construct(Player player) => _player = player;


        #endregion

        private void Awake() => _bullet = transform;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            Vector2 MoveDirection = (_player.transform.position - _bullet.position).normalized * _speed;
            _bulletRigidbody2D.velocity = new Vector2(MoveDirection.x, MoveDirection.y);
            StartCoroutine(Death());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ITakeDamage hit))
            {
                hit.TakeDamage(3);
            }
            Destroy(_bullet.gameObject);
        }

        private IEnumerator Death()
        {
            yield return new WaitForSeconds(_timeToDeath);
            Destroy(_bullet.gameObject);

        }
        
    }
}
