using System.Collections;
using System.Collections.Generic;
using TenEnemy;
using UnityEngine;
using UnityEngine.Events;

namespace TenSeconds
{
    public class CheckEnemy : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<bool> OnEndLevel;
        public List<HealthEnemy> Enemies;
        private bool IsEndLevel;

        private void Start()
        {
            StartCoroutine(Check());
        }

        IEnumerator Check()
        {
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(() => Enemies.Count == 0);
            IsEndLevel = true;
            OnEndLevel?.Invoke(IsEndLevel);
        }
        
    }
}
