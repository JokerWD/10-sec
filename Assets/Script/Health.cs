using UnityEngine;


namespace TenSeconds
{
    public abstract class Health : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _health;
        protected bool IsDie;
        private GameObject _thisGameObject;

        private void Awake() => _thisGameObject = gameObject;

        public virtual void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                IsDie = true;
                _thisGameObject.SetActive(false);
            }

        }
    }
}
