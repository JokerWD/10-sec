using DG.Tweening;
using UnityEngine;

namespace TenEnemy
{
    public class EnemyFlyMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _finalPosition;

        private int _currentPoint;
        public void Move()
        {
            transform.DOMove(_finalPosition.position, _speed).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
        }

      
    }
}
