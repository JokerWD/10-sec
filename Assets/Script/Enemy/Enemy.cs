using System;
using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class Enemy : MonoBehaviour
    {
        [Header("DISTANCE")]
        [SerializeField] private float _range;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _position;
        private Player _player;
        private Transform _playerTransform;
        private Transform _enemyTransform;
        private float _distanceToPlayer;


        [SerializeField] private float _fireRate = 1f;
        private float _nextFireTime;
        
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
            if (_distanceToPlayer <= _range)
            {
                if (_playerTransform.position.x > _enemyTransform.position.x && _enemyTransform.localScale.x < 0)
                {
                    Flip();
                }else if (_playerTransform.position.x < _enemyTransform.position.x && _enemyTransform.localScale.x > 0)
                {
                    Flip();
                }

                if (_nextFireTime < Time.time)
                {
                    Shoot();                
                }
            }
        }


        private void Flip() => _enemyTransform.localScale = new Vector2(_enemyTransform.localScale.x * -1, _enemyTransform.localScale.y);

        private void Shoot()
        {
            Instantiate(_bullet, _position.position, Quaternion.identity);
            _nextFireTime = Time.time + _fireRate;
        }
    }
}
