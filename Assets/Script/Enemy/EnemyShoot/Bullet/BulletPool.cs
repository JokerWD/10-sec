using UnityEngine;
using UnityEngine.Pool;

namespace TenEnemy
{
    public class BulletPool : MonoBehaviour
    {
        [field: SerializeField] public int BulletCount { get; private set; } = 100;
        [field: SerializeField] public Bullet BulletPrefab { get; private set; }
        [field: SerializeField] public IObjectPool<Bullet> PoolBullet { get; private set; }

        private void Awake()
        {
            var maxBulletsMultiplier = 2;
            
            PoolBullet = new ObjectPool<Bullet>(OnCreateArrow, OnGetArrow, OnDisableArrow, OnDestroyArrow,
                true, BulletCount * maxBulletsMultiplier);
        }

        private void OnDestroyArrow(Bullet bullet) => Destroy(bullet.gameObject);

        private void OnGetArrow(Bullet bullet)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.SetParent(transform, true);
        }

        private void OnDisableArrow(Bullet bullet) => bullet.gameObject.SetActive(false);

        private Bullet OnCreateArrow()
        {
            var bullet = Instantiate(BulletPrefab);
            bullet.SetPool(PoolBullet);
            bullet.gameObject.SetActive(false);
            return bullet;
        }
    }
}