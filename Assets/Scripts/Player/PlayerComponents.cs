using UnityEngine;

namespace VladB.ZigZag.MainPlayer
{
    public class PlayerComponents : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        public Mover Mover => _mover;


        [SerializeField] private Rigidbody _rigidbody;
        public Rigidbody MainRigidBody => _rigidbody;
    }
}