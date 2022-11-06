using UnityEngine;

namespace TenSeconds
{
    public class HealthPlayer : Health
    {
        [SerializeField] private GameObject healthUI;
        
        public bool PlayerDead { get; private set; }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            healthUI.gameObject.SetActive(false);
            if(IsDie)
                PlayerDead = true;
        }
        
       
       
    }
}
