using System.Collections;
using UnityEngine;

namespace TenSeconds
{
    public class MeleeWeapon : MonoBehaviour
    {
        [SerializeField] private CapsuleCollider2D capsuleCollider2D;
        [SerializeField] private Animator animator;
        [SerializeField] private float delay = 0.3f;
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
            capsuleCollider2D.enabled = true;
            animator.SetBool("IsAttack", true);
            yield return new WaitForSeconds(delay);
            capsuleCollider2D.enabled = false;
            _isAttack = false;
            animator.SetBool("IsAttack", false);
        }

    }
}
