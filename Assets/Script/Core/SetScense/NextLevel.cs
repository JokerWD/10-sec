using System;
using TenSeconds;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TenCore
{
    public class NextLevel : MonoBehaviour
    {
        private CheckEnemy _checkEnemy;
        
        #region Zenject

        [Inject]
        private void Construct(CheckEnemy checkEnemy) => _checkEnemy = checkEnemy;
        
        #endregion

        private void Start()
        {
            _checkEnemy.onEndLevel.AddListener((IsEndLevel) =>
            {
                NextLevelLoad();
            });
        }
        private void NextLevelLoad() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}