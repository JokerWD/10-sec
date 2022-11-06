using System.Collections;
using System.Collections.Generic;
using TenEnemy;
using UnityEngine;
using UnityEngine.Events;

namespace TenCore
{
    public class CheckEnemy : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<bool> onEndLevel;
        public List<HealthEnemy> enemies;
        private bool _isEndLevel;

        private void Start()
        {
            StartCoroutine(Check());
        }

        IEnumerator Check()
        {
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => enemies.Count == 0);
            _isEndLevel = true;
            onEndLevel?.Invoke(_isEndLevel);
        }
        
    }
}
