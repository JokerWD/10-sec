using Dythervin.AutoAttach;
using UnityEngine;
using UnityEngine.UI;

namespace TenSeconds
{
    public class Timer : MonoBehaviour
    {
        [SerializeField, Attach(Attach.Scene)] private Text _timeText;
        public float TimeValue { get; private set; } = 10f;

        private float seconds;

        private void Update()
        {
            if (TimeValue > 0)
                TimeValue -= Time.deltaTime;
            else
                TimeValue = 0;
            
            DisplayTime(TimeValue);
        }

        private void DisplayTime(float timeToDisplay)
        {
            if (timeToDisplay < 0)
                timeToDisplay = 0;

            seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _timeText.text = $"{seconds}";
        }
    }
}
