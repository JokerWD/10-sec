using System.Collections.Generic;
using UnityEngine;

namespace TenEnemy
{
    public class EnemyFlyMove : MonoBehaviour
    {
        [SerializeField] private List<Transform> _pointsMove;
        [SerializeField] private float _speed;

        private Transform _enemyTransform;
        private int _currentPoint;
        private Transform _target;


        private void Awake()
        {
            _enemyTransform = transform;
        }

        public void Move()
        {
            _target = _pointsMove[_currentPoint];

            _enemyTransform.position = Vector3.MoveTowards(_enemyTransform.position, _target.position, _speed * Time.deltaTime);
            
            CheckPosition();
        }

        private void CheckPosition()
        {
            if (_enemyTransform.position == _target.position)
            {
                _currentPoint++;

                if (_currentPoint >= _pointsMove.Capacity)
                {
                    _currentPoint = 0;
                }
            }
        }
    }
}
