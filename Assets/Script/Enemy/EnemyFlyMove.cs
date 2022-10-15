using DG.Tweening;
using UnityEngine;

namespace TenEnemy
{
    public class EnemyFlyMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float xMove;
        [SerializeField] private float yMove;
        
        

        private int _currentPoint;
        public void Move()
        {
            var position = transform.position;
            var newVector2 = new Vector2(position.x + xMove, position.y + yMove);
            transform.DOMove(newVector2, speed)
                .SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        }

      
    }
}
