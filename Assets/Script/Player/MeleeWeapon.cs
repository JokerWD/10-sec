using System;
using System.Collections;
using UnityEngine;

namespace TenSeconds
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.3f;
        [SerializeField] private Transform _circleOrigin;
        [SerializeField] private float _radius;
        private bool _isAttack;


        public void Attack()
        {
            if(_isAttack)
                return;
            
            print("Yes");
            _isAttack = true;
            StartCoroutine(DelayAttack());
        }

        private IEnumerator DelayAttack()
        {
            yield return new WaitForSeconds(_delay);
            _isAttack = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Vector3 position = _circleOrigin == null ? Vector3.zero : _circleOrigin.position;
            Gizmos.DrawWireSphere(position, _radius);
        }

        //запихнуть в анимацию 
        private void DetectColliders()
        {
            foreach (Collider2D collider2D in Physics2D.OverlapCircleAll(_circleOrigin.position, _radius))
            {
                print(collider2D.name);
                if (collider2D.TryGetComponent(out ITakeDamage health))
                {
                    health.TakeDamage(2);
                }
            }
        }
    }
}
