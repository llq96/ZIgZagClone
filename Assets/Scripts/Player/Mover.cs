using UnityEngine;

namespace VladB.ZigZag.MainPlayer
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 CurrentDirection => _directionContext.State.Direction;
        private Rigidbody _rigidbody;

        private DirectionContext _directionContext;

        public void Init(Rigidbody movingRigidbody)
        {
            _rigidbody = movingRigidbody;

            _directionContext = new DirectionContext(new DirectionRight());
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SwitchDirection();
            }
        }

        public void SwitchDirection()
        {
            _directionContext.SwitchDirection();
            _rigidbody.velocity = CurrentDirection * _speed;
        }
    }

    public interface IDirectionState
    {
        public Vector3 Direction { get; }
        public IDirectionState SwitchDirection();
    }

    public class DirectionContext
    {
        public DirectionContext(IDirectionState state)
        {
            State = state;
        }

        public IDirectionState State { get; private set; }

        public void SwitchDirection()
        {
            State = State.SwitchDirection();
        }
    }

    public class DirectionForward : IDirectionState
    {
        public Vector3 Direction => Vector3.forward;

        public IDirectionState SwitchDirection()
        {
            return new DirectionRight();
        }
    }

    public class DirectionRight : IDirectionState
    {
        public Vector3 Direction => Vector3.right;

        public IDirectionState SwitchDirection()
        {
            return new DirectionForward();
        }
    }
}