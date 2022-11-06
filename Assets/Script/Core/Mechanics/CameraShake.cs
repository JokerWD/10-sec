using DG.Tweening;
using UnityEngine;

namespace TenCore
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float shakeTime;
        [SerializeField] private float shakePower;
        
        
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Shake()
        {
            _camera.DOShakeRotation(shakeTime, shakePower);
        }
    }
}
