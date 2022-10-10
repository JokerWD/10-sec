using System;
using UnityEngine;

namespace TenEnemy
{
    public class BulletSpawn : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;

        private void Start()
        {
            GenerateBullet();
        }

        private void GenerateBullet()
        {
            for (int i = 0; i < _bulletPool.BulletCount; i++)
                CreateBullet();
            
        }

        private void CreateBullet()
        {
            var bullet = _bulletPool.PoolBullet.Get();
            bullet.gameObject.SetActive(false);
        }

        public void SetBullet(Vector2 position, Vector2 Direction)
        {
            var bullet = _bulletPool.PoolBullet.Get();
            bullet.gameObject.transform.position = position;
            bullet.MoveDirection = Direction;
            bullet.gameObject.SetActive(true);
        }
    }
}
