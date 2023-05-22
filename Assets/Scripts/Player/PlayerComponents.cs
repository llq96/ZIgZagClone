using UnityEngine;

namespace VladB.ZigZag.MainPlayer
{
    public class PlayerComponents : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody MainRigidBody => _rigidbody;
    }
}