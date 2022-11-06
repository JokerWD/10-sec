using Dythervin.AutoAttach;
using UnityEngine;
using Zenject;
using TenSeconds;

namespace TenCore
{
    public class LoseGame : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Scene)] private GameObject _deathUI;
        private HealthPlayer _playerHealth;

        private Timer _timer;

        #region Zenject

        [Inject]
        private void Construct(Timer time, HealthPlayer healthPlayer)
        {
            _timer = time;
            _playerHealth = healthPlayer;
        } 
            


        #endregion
        
        private void Update()
        {
            if(_playerHealth.PlayerDead)
                SetDeathUI();
            if(_timer.TimeValue < 0)
                SetDeathUI();
            
        }

        private void SetDeathUI() => _deathUI.SetActive(true);
    }
}
