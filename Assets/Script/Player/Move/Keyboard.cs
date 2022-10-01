using UnityEngine;
using TarodevController;
using Zenject;

namespace TenSeconds
{
    public class Keyboard : MonoBehaviour
    {
        private PlayerController _playerController; 

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftControl)) 
                _playerController.Dash();
            
        }
    }
}
