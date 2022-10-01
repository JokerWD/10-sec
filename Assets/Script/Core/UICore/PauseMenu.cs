using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TenCore
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private Button _playButton;

        private void OnEnable()
        {
            _homeButton.onClick.AddListener(GoHome);
            _playButton.onClick.AddListener(SetCanvas);
        }

        private void OnDisable()
        {
            _homeButton.onClick.RemoveListener(GoHome);
            _playButton.onClick.RemoveListener(SetCanvas);
        }

        private void GoHome() => SceneManager.LoadScene(0);

        private void SetCanvas()
        {
            Time.timeScale = 1f;
            _canvas.SetActive(false);
        }
    }
}
