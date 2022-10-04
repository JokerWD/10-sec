using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace TenSeconds
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _bulletRigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private int _timeToDeath;
        public Vector2 MoveDirection { private get; set; }
        

        private IObjectPool<Bullet> _bulletPool;

        #region Zenject

       // [Inject]
      //  private void Construct(Player player) => _player = player;


        #endregion

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


        public void SetPool(IObjectPool<Bullet> bulletPool) => _bulletPool = bulletPool;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ITakeDamage hit))
            {
                hit.TakeDamage(3);
                _bulletPool.Release(this);
            }
        }


        private void SetDirection()
        {
            MoveDirection *= _speed;
            _bulletRigidbody2D.velocity = new Vector2(MoveDirection.x, MoveDirection.y);
        } 


        private IEnumerator Death()
        {
            yield return new WaitForSeconds(_timeToDeath);
            _bulletPool.Release(this);
        }
        
    }
}
