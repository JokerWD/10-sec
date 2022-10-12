using UnityEngine;

namespace TenEnemy
{
    public class BulletSpawn : MonoBehaviour
    {
        [SerializeField] private BulletPool bulletPool;

        private void Start() => GenerateBullet();

        private void GenerateBullet()
        {
            for (int i = 0; i < bulletPool.BulletCount; i++)
                CreateBullet();
            
        }

        private void CreateBullet()
        {
            var bullet = bulletPool.PoolBullet.Get();
            bullet.gameObject.SetActive(false);
        }

        public void SetBullet(Vector2 position, Vector2 direction)
        {
            var bullet = bulletPool.PoolBullet.Get();
            bullet.gameObject.transform.position = position;
            bullet.MoveDirection = direction;
            bullet.gameObject.SetActive(true);
        }
    }
}