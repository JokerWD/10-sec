using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TenSeconds
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private Text _timeText;
        private float _timeValue = 10f;

        private void Update()
        {
            if (_timeValue > 0)
                _timeValue -= Time.deltaTime;
            else
                _timeValue = 0;
            
            DisplayTime(_timeValue);
        }

        private void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
                timeToDisplay = 0;

            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _timeText.text = string.Format("{0}", seconds);
        }
    }
}
