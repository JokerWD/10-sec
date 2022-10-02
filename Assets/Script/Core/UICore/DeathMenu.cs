using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class DeathMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _homeButton.onClick.AddListener(GoHome);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            _homeButton.onClick.RemoveListener(GoHome);
            _restartButton.onClick.RemoveListener(RestartGame);
        }

        private void Update() => Time.timeScale = _canvas.activeSelf ? 0f : 1f;

        private void GoHome() => SceneManager.LoadScene(0);

        
        private void RestartGame()
        {
            _canvas.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
