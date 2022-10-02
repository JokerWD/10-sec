using UnityEngine;

namespace TenSeconds
{
    public class Heath : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private int _health;
        [SerializeField] private bool _isPlayer;
        
        public bool PlayerDead { get; private set; }

        private GameObject _thisGameObject;

        private void Awake() => _thisGameObject = gameObject;

        public void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                if (_isPlayer)
                    PlayerDead = true;
                
                _thisGameObject.SetActive(false);
            }

        }
    }
}
