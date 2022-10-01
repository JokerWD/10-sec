using UnityEngine;
using TarodevController;
using Zenject;

namespace TenSeconds
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        private PlayerController _playerController;
        private MeleeWeapon _meleeWeapon;

        #region Zenject
        [Inject]
        private void Construct(PlayerController playerController, MeleeWeapon meleeWeapon)
        {
            _playerController = playerController;
            _meleeWeapon = meleeWeapon;
        }
        #endregion
     

    
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftControl)) 
                _playerController.Dash();
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _pauseMenu.SetActive(!_pauseMenu.activeSelf);
                if(_pauseMenu.activeSelf)
                    Time.timeScale = 0f;
                else
                    Time.timeScale = 1f;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _meleeWeapon.Attack();
            }
            
        }
    }
}
