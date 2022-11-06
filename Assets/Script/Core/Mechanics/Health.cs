using System;
using UnityEngine;
using UnityEngine.Events;


namespace TenSeconds
{
    public abstract class Health : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int health;
        [HideInInspector] public UnityEvent<float> HealthChanged;
        [HideInInspector] public UnityEvent<bool> IsDied;
        
        protected bool IsDie;
        private GameObject _thisGameObject;

        private void Awake() => _thisGameObject = gameObject;

        public virtual void TakeDamage(int amount)
        {
            health -= amount;
            HealthChanged?.Invoke(health);
            if (health <= 0)
            {
                IsDie = true;
                HealthChanged?.Invoke(0);
                IsDied?.Invoke(IsDie);
                _thisGameObject.SetActive(false);
            }

        }
    }
}
