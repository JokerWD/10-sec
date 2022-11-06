using TenCore;
using TenSeconds;
using UnityEngine;

namespace TenEnemy
{
    public class HealthEnemy : Health
    {
        [SerializeField] private CheckEnemy listCheck;
        
        private void Start()
        {
            listCheck.enemies.Add(this);
            IsDied.AddListener((IsDie) =>
            {
                listCheck.enemies.Remove(this);
            });
        }

        
    }
}
