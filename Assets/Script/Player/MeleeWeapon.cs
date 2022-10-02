using System.Collections;
using UnityEngine;

namespace TenSeconds
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider2D _collider2D;
        [SerializeField] private float _delay = 0.3f;
        private bool _isAttack;


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ITakeDamage hit))
                hit.TakeDamage(2);
        }

        public void Attack()
        {
            if(_isAttack)
                return;
            
            _isAttack = true;
            StartCoroutine(DelayAttack());
        }

        private IEnumerator DelayAttack()
        {
            _collider2D.enabled = true;
            yield return new WaitForSeconds(_delay);
            _collider2D.enabled = false;
            _isAttack = false;
        }

    }
}
