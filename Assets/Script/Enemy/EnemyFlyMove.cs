using DG.Tweening;
using UnityEngine;

namespace TenEnemy
{
    public class EnemyFlyMove : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform finalPosition;

        private int _currentPoint;
        public void Move()
        {
            transform.DOMove(finalPosition.position, speed).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        }

      
    }
}
