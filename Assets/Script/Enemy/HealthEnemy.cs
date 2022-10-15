using TenSeconds;
using UnityEngine;

namespace TenEnemy
{
    public class HealthEnemy : Health
    {
        [SerializeField] private CheckEnemy listCheck;
        
        private void Start()
        {
            listCheck.Enemies.Add(this);
            IsDied.AddListener((IsDie) =>
            {
                listCheck.Enemies.Remove(this);
            });
        }

        
    }
}
