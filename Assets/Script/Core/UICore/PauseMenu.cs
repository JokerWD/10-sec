using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button soundButton;
        [SerializeField] private Button playButton;

        private void OnEnable()
        {
            homeButton.onClick.AddListener(GoHome);
            playButton.onClick.AddListener(SetCanvas);
        }

        private void OnDisable()
        {
            homeButton.onClick.RemoveListener(GoHome);
            playButton.onClick.RemoveListener(SetCanvas);
        }

        private void GoHome() => SceneManager.LoadScene(0);

        private void SetCanvas()
        {
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }
    }
}
