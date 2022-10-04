using UnityEngine;

namespace TenSeconds
{
    public class HealthPlayer : Health
    {
        [SerializeField] private GameObject _healthUI;
        
        public bool PlayerDead { get; private set; }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            _healthUI.gameObject.SetActive(false);
            if(IsDie)
                PlayerDead = true;
        }
        
       
       
    }
}
