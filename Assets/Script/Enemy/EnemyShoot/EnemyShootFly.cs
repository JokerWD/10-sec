using UnityEngine;
using Zenject;

namespace TenEnemy
{
    public class EnemyShootFly : Shooting
    { 
        private BulletSpawn _bulletSpawn;

        #region Zenject

        [Inject]
        private void Construct(BulletSpawn bulletSpawn) => _bulletSpawn = bulletSpawn;

        #endregion
        
        
       public override void TryShoot()
       { 
           if(NextFireTime < Time.time) 
               FlyShoot();
       }
       
      private void FlyShoot()
      {
          MoveDirection = Vector2.down;
          _bulletSpawn.SetBullet(fireTransform.position, MoveDirection);

          NextFireTime = Time.time + FireRate;
      }
    }
}