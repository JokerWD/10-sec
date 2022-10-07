using System;
using UnityEngine;
using Zenject;

namespace TenSeconds
{
    [RequireComponent(typeof(EnemyShoot), typeof(PlayerInZone))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _data;

        private EnemyShoot _enemyShoot;
        private PlayerInZone _playerInZone;
        private bool _playerInZoneRange;
        
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
        }

        private void Update()
        {
            _playerInZoneRange = _playerInZone.PlayerInZoneRange;
            
            _playerInZone.DistanceOnPlayer(_playerTransform);
            _enemyShoot.TryShoot(_playerInZoneRange, _playerTransform);
        }
    }
}
