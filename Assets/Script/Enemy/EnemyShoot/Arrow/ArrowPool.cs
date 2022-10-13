using UnityEngine;
using UnityEngine.Pool;

namespace TenEnemy
{
    public class ArrowPool : MonoBehaviour
    {
        [field: SerializeField] public int ArrowCount { get; private set; } = 100;
        [field: SerializeField] public Arrow ArrowPrefab { get; private set; }
        [field: SerializeField] public IObjectPool<Arrow> PoolBullet { get; private set; }

        private void Awake()
        {
            var maxBulletsMultiplier = 2;
            
            PoolBullet = new ObjectPool<Arrow>(OnCreateArrow, OnGetArrow, OnDisableArrow, OnDestroyArrow,
                                                true, ArrowCount * maxBulletsMultiplier);
        }

        private void OnDestroyArrow(Arrow arrow) => Destroy(arrow.gameObject);

        private void OnGetArrow(Arrow arrow)
        {
            arrow.gameObject.SetActive(true);
            arrow.transform.SetParent(transform, true);
        }

        private void OnDisableArrow(Arrow arrow) => arrow.gameObject.SetActive(false);

        private Arrow OnCreateArrow()
        {
            var arrow = Instantiate(ArrowPrefab);
            arrow.SetPool(PoolBullet);
            arrow.gameObject.SetActive(false);
            return arrow;
        }
    }
}
