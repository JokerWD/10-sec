using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class ScenesLoad : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        private AudioSource _audio;
        
        private void Start()
        {
            startButton.onClick.AddListener(StartButtonPressed);
            _audio = startButton.GetComponent<AudioSource>();
        }

        private void OnDisable() => startButton.onClick.RemoveListener(StartButtonPressed);

        private void StartButtonPressed() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
