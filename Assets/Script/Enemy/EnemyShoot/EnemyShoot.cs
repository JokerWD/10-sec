using System;
using Dythervin.AutoAttach;
using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class EnemyShoot : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Child)] private Transform _position;
        [SerializeField] private BulletSpawn _bulletSpawn;
        
        public float FireRate { private get; set; }
        
        private Player _player;
        private PlayerInZone _playerInZone;
        private float _nextFireTime;
        
        #region Zenject

        [Inject]
        private void Construct(Player player) => _player = player;
        
        #endregion

        private void Awake() => _playerInZone = GetComponent<PlayerInZone>();

        private void Update()
        {
            if (_playerInZone.PlayerInZoneRange)
                if (_nextFireTime < Time.time)
                    Shoot();
        }

        private void Shoot()
        {
            Vector2 MoveDirection = (_player.transform.position - _position.position).normalized;
            _bulletSpawn.SetBullet(_position.position, MoveDirection);
            
            _nextFireTime = Time.time + FireRate;
        }
    }
}
