using System;
using UnityEngine;
using Zenject;
using TenSeconds;

namespace TenEnemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;
        
        private EnemyShootStatic _enemyShootStatic;
        private EnemyFlyMove _enemyFlyMove;
        private EnemyShootFly _enemyShootFly;
        
        private SpriteRenderer _sprite;
        private PlayerInZone _playerInZone;
        private bool _playerInZoneRange;
        private event Action OnShoot;

        [Header("PLAYER")]
        private Player _player;
        private Transform _playerTransform;

        
        #region Zenject

        [Inject]
        private void Construct(Player player) => _player = player;
        
        #endregion

        private void Awake()
        {
            _playerTransform = _player.transform;
            _sprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _sprite.sprite = _data.EnemySprite;
            CheckStateEnemy();
           
        }

        
        #region Event

        private void OnDisable()
        {
            OnShoot -= Fire;
            OnShoot -= FireFly;
        }

        private void OnEnable()
        {
            if (_data.EnemyType == EnemyType.Static)
                OnShoot += Fire;
            else
                OnShoot += FireFly;
        }
        

        #endregion
        

        private void Update() => OnShoot?.Invoke();
        
        private void CheckStateEnemy()
        {
            if (_data.EnemyType == EnemyType.Static)
            {
                _enemyShootStatic = GetComponent<EnemyShootStatic>();
                _playerInZone = GetComponent<PlayerInZone>();
                _enemyShootStatic.FireRate = _data.FireRate;
                _playerInZone.Range = _data.Range;
                OnShoot += Fire;
            }
            else
            {
                _enemyFlyMove = GetComponent<EnemyFlyMove>();
                _enemyShootFly = GetComponent<EnemyShootFly>();
                _enemyShootFly.FireRate = _data.FireRate;
                
                OnShoot += FireFly;
                Move();
            }
        }
        

        private void Fire()
        {
            _playerInZoneRange = _playerInZone.PlayerInZoneRange;
            
            _playerInZone.DistanceOnPlayer(_playerTransform);
            _enemyShootStatic.TryShoot(_playerInZoneRange, _playerTransform);
        }
        
        private void FireFly() => _enemyShootFly.TryShoot();

        private void Move() => _enemyFlyMove.Move();
    }
}
