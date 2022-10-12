using UnityEngine;
using Zenject;

namespace TenEnemy
{
    public sealed class EnemyShootStatic : Shooting
    { 
        private ArrowSpawn _arrowSpawn;

        #region Zenject
        
        [Inject]
        private void Construct(ArrowSpawn arrowSpawn) => _arrowSpawn = arrowSpawn;

        #endregion
        
        public void TryShoot(bool inZone, Transform player)
        {
            if (inZone)
                if (NextFireTime < Time.time)
                    Shoot(player);
        }

        private  void Shoot(Transform player)
        {
            MoveDirection = (player.position - fireTransform.position).normalized;
            _arrowSpawn.SetArrow(fireTransform.position, MoveDirection);
            
            NextFireTime = Time.time + FireRate;
        }
    }
}
