using UnityEngine;

namespace TenSeconds
{
    public class Heath : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isPlayer;
        
        public bool _isPlayerDead { get; private set; }

        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                if (_isPlayer)
                    _isPlayerDead = true;
            }

        }
    }
}
