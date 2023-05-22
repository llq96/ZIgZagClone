using UnityEngine;

namespace VladB.ZigZag
{
    public class TilesMaterialsHelper : MonoBehaviour
    {
        private static readonly int PlayerPositionID = Shader.PropertyToID("_PlayerPosition");

        [SerializeField] private Material _tileMaterial;

        private Transform _playerTransform;

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        private void Update()
        {
            UpdateMaterials();
        }

        private void UpdateMaterials()
        {
            if (_playerTransform != null)
            {
                Vector3 playerPosition = _playerTransform.position;
                if (_tileMaterial != null) _tileMaterial.SetVector(PlayerPositionID, playerPosition);
            }
        }

        private void OnDestroy()
        {
            if (_tileMaterial != null) _tileMaterial.SetVector(PlayerPositionID, Vector3.zero);
        }
    }
}