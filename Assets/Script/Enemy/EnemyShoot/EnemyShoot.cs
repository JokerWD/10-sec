using Dythervin.AutoAttach;
using UnityEngine;

namespace TenSeconds
{
    public class EnemyShoot : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Child)] private Transform _fireTransform;
        [SerializeField] private BulletSpawn _bulletSpawn;
        
        public float FireRate { private get; set; }
        private float _nextFireTime;
        

        

        public void TryShoot(bool InZone, Transform player)
        {
            if (InZone)
                if (_nextFireTime < Time.time)
                    Shoot(player);
        }

        private void Shoot(Transform player)
        {
            Vector2 MoveDirection = (player.position - _fireTransform.position).normalized;
            _bulletSpawn.SetBullet(_fireTransform.position, MoveDirection);
            
            _nextFireTime = Time.time + FireRate;
        }
    }
}
