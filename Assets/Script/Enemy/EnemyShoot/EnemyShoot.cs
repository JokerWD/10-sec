using Dythervin.AutoAttach;
using UnityEngine;

namespace TenEnemy
{
    public  class EnemyShoot : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Child)] private Transform _fireTransform;
        [SerializeField, Attach(Attach.Scene)] private BulletSpawn _bulletSpawn;
        
        public float FireRate { private get; set; }
        private float _nextFireTime;
        private Vector2 MoveDirection;
        

        

        public virtual void TryShoot(bool InZone, Transform player)
        {
            if (InZone)
                if (_nextFireTime < Time.time)
                    Shoot(player);
        }

        public void TryShoot()
        {
            if(_nextFireTime < Time.time)
                FlyShoot();
        }

        private  void Shoot(Transform player)
        {
             MoveDirection = (player.position - _fireTransform.position).normalized;
            _bulletSpawn.SetBullet(_fireTransform.position, MoveDirection);
            
            _nextFireTime = Time.time + FireRate;
        }

        private void FlyShoot()
        {
            MoveDirection = Vector2.down;
            _bulletSpawn.SetBullet(_fireTransform.position, MoveDirection);

            _nextFireTime = Time.time + FireRate;
        }
    }
}
