using UnityEngine;

namespace VladB.ZigZag
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        public Camera MainCamera => _mainCamera;

        [SerializeField] private Vector3 _positionOffset;

        private Transform _followTransform;

        public void Init(Transform followTransform)
        {
            _followTransform = followTransform;
        }

        private void Update()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            if (_followTransform == null) return;
            transform.position = _followTransform.position + _positionOffset;
        }
    }
}