using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class DeathMenu : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button soundButton;
        [SerializeField] private Button restartButton;

        private void OnEnable()
        {
            homeButton.onClick.AddListener(GoHome);
            restartButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            homeButton.onClick.RemoveListener(GoHome);
            restartButton.onClick.RemoveListener(RestartGame);
        }

        private void Update() => Time.timeScale = canvas.activeSelf ? 0f : 1f;

        private void GoHome() => SceneManager.LoadScene(0);

        
        private void RestartGame()
        {
            canvas.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
