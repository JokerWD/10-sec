using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using TenSeconds;

namespace TenEnemy
{
    public class Arrow : Shell
    {
        private IObjectPool<Arrow> _arrowPool;
        
        public void SetPool(IObjectPool<Arrow> arrowPool) => _arrowPool = arrowPool;
        
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
                _arrowPool.Release(this);
            }
        }
        
        private IEnumerator Death()
        {
            yield return new WaitForSeconds(timeToDeath); 
            _arrowPool.Release(this);
        }
        
    }
}
