using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class PlayerInZone : MonoBehaviour
    {
        public bool PlayerInZoneRange { get; private set; }
        public float Range { private get; set; }
        
        private Player _player;
        private Transform _playerTransform;
        private Transform _enemyTransform;
        private float _distanceToPlayer;


        #region Zenject

        [Inject]
        private void Construct(Player player) => _player = player;
        
        #endregion
        private void Awake()
        {
            _playerTransform = _player.transform;
            _enemyTransform = transform;
        }

        private void Update()
        {
            _distanceToPlayer = Vector2.Distance(_enemyTransform.position, _playerTransform.position);
            if (_distanceToPlayer <= Range)
            {
                CheckPlayer();
                PlayerInZoneRange = true;
            }
            else
            {
                PlayerInZoneRange = false;
            }
            
        }

        private void CheckPlayer()
        {
            if (_playerTransform.position.x > _enemyTransform.position.x && _enemyTransform.localScale.x < 0)
            {
                Flip();
            }else if (_playerTransform.position.x < _enemyTransform.position.x && _enemyTransform.localScale.x > 0) 
            { 
                Flip();
            }
        }
        
        private void Flip() => _enemyTransform.localScale = new Vector2(_enemyTransform.localScale.x * -1, _enemyTransform.localScale.y);

    }
}
