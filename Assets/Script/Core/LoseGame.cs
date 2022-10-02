using UnityEngine;

namespace TenSeconds
{
    public class LoseGame : MonoBehaviour
    {
        [SerializeField] private GameObject _deathUI;
        [SerializeField] private Heath _playerHeath;
        
        private void Update()
        {
            if(_playerHeath.PlayerDead)
                SetDeathUI();
        }

        private void SetDeathUI() => _deathUI.SetActive(true);
    }
}
