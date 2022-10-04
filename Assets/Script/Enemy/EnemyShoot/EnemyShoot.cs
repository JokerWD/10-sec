using System;
using Dythervin.AutoAttach;
using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class EnemyShoot : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Child)] private Transform _position;
        [SerializeField] private Bullet _bullet;
        
        public float FireRate { private get; set; }
        
        private PlayerInZone _playerInZone;
        private float _nextFireTime;

        private void Awake() => _playerInZone = GetComponent<PlayerInZone>();

        private void Update()
        {
            if (_playerInZone.PlayerInZoneRange)
                if (_nextFireTime < Time.time)
                    Shoot();
        }

        private void Shoot()
        {
            Instantiate(_bullet, _position.position, Quaternion.identity);
            _nextFireTime = Time.time + FireRate;
        }
    }
}
