using UnityEngine;

namespace TenEnemy
{
    public class ArrowSpawn : MonoBehaviour
    {
        [SerializeField] private ArrowPool arrowPool;

        private void Start() => GenerateArrow();

        private void GenerateArrow()
        {
            for (int i = 0; i < arrowPool.ArrowCount; i++)
                CreateArrow();
            
        }

        private void CreateArrow()
        {
            var arrow = arrowPool.PoolBullet.Get();
            arrow.gameObject.SetActive(false);
        }

        public void SetArrow(Vector2 position, Vector2 direction)
        {
            var arrow = arrowPool.PoolBullet.Get();
            arrow.gameObject.transform.position = position;
            arrow.MoveDirection = direction;
            arrow.gameObject.SetActive(true);
        }
    }
}
