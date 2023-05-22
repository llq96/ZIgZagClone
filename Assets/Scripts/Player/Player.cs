using UnityEngine;


namespace VladB.ZigZag.MainPlayer
{
    [RequireComponent(typeof(PlayerComponents))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        private PlayerComponents _playerComponents;

        public void Init()
        {
            _playerComponents = GetComponent<PlayerComponents>();

            _mover.Init(_playerComponents.MainRigidBody);
        }
    }
}