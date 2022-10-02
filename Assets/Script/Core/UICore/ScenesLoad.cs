using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class ScenesLoad : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        private AudioSource _audio;
        
        private void Start()
        {
            _startButton.onClick.AddListener(StartButtonPressed);
            _audio = _startButton.GetComponent<AudioSource>();
        }

        private void OnDisable() => _startButton.onClick.RemoveListener(StartButtonPressed);

        private void StartButtonPressed() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
