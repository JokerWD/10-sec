using UnityEngine;
using TarodevController;
using TenCore;
using Zenject;

namespace TenSeconds
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private PlayerController _playerController;
        private CameraShake _cameraShake;
        private MeleeWeapon _meleeWeapon;

        #region Zenject
        [Inject]
        private void Construct(PlayerController playerController, MeleeWeapon meleeWeapon, CameraShake cameraShake)
        {
            _playerController = playerController;
            _meleeWeapon = meleeWeapon;
            _cameraShake = cameraShake;
        }
        #endregion
     

    
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftControl)) 
                _playerController.Dash();
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if(pauseMenu.activeSelf)
                    Time.timeScale = 0f;
                else
                    Time.timeScale = 1f;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _meleeWeapon.Attack();
                _cameraShake.Shake();
            }
            
        }
    }
}
