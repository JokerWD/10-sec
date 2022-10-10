using System;
using UnityEngine;
using Zenject;
using TenSeconds;

namespace TenEnemy
{
    [RequireComponent(typeof(EnemyShoot), typeof(PlayerInZone))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;
        
        private EnemyFlyMove _enemyFlyMove;
        private EnemyShoot _enemyShoot;
        private PlayerInZone _playerInZone;
        private bool _playerInZoneRange;
        private event Action OnAction;

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
            _enemyShoot = GetComponent<EnemyShoot>();
            _playerInZone = GetComponent<PlayerInZone>();
        }

        private void Start()
        {
            _enemyShoot.FireRate = _data.FireRate;
            _playerInZone.Range = _data.Range;

            if (_data.EnemyType == EnemyType.Static)
            {
                OnAction += Fire;
            }
            else
            {
                _enemyFlyMove = GetComponent<EnemyFlyMove>();
                OnAction += FireFly;
                OnAction += Move;

            }
        }

        #region Event

        private void OnDisable()
        {
            OnAction -= Fire;
            OnAction -= FireFly;
        }

        private void OnEnable()
        {
            if (_data.EnemyType == EnemyType.Static)
            {
                OnAction += Fire;
            }
            else
            {
                OnAction += FireFly;
                OnAction += Move;

            }
        }
        

        #endregion
        

        private void Update() => OnAction?.Invoke();

        private void Fire()
        {
            _playerInZoneRange = _playerInZone.PlayerInZoneRange;
            
            _playerInZone.DistanceOnPlayer(_playerTransform);
            _enemyShoot.TryShoot(_playerInZoneRange, _playerTransform);
        }

        private void FireFly() => _enemyShoot.TryShoot();

        private void Move() => _enemyFlyMove.Move();
    }
}
