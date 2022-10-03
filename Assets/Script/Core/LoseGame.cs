using UnityEngine;
using Zenject;

namespace TenSeconds
{
    public class LoseGame : MonoBehaviour
    {
        [SerializeField] private GameObject _deathUI;
        [SerializeField] private Heath _playerHeath;

        private Timer _timer;

        #region Zenject

        [Inject]
        private void Construct(Timer time) => _timer = time;


        #endregion
        
        private void Update()
        {
            if(_playerHeath.PlayerDead)
                SetDeathUI();
            if(_timer.TimeValue < 0)
                SetDeathUI();
            
        }

        private void SetDeathUI() => _deathUI.SetActive(true);
    }
}
