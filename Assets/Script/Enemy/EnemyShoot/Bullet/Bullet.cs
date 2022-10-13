using System.Collections;
using TenSeconds;
using UnityEngine;
using UnityEngine.Pool;

namespace TenEnemy
{
    public class Bullet : Shell
    {
        private IObjectPool<Bullet> _bulletPoll;

        public void SetPool(IObjectPool<Bullet> bulletPool) => _bulletPoll = bulletPool;
        
        #region Direction
        
        private void Start()
        {
            SetDirection();
            StartCoroutine(Death());
        }

        private void OnEnable()
        {
            SetDirection();
            StartCoroutine(Death());
        }

        private void OnDisable() => StopCoroutine(Death());
        
        #endregion

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ITakeDamage hit))
            {
                hit.TakeDamage(3);
                _bulletPoll.Release(this);
            }
        }


        private IEnumerator Death()
        {
            yield return new WaitForSeconds(timeToDeath);
            _bulletPoll.Release(this);
        }
    }
}