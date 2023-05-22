using UnityEngine;

namespace VladB.ZigZag.MainPlayer
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 CurrentDirection => _directionContext.State.Direction;
        private Rigidbody _rigidbody;

        private DirectionContext _directionContext;
        private Vector3 _startPosition;

        public void Init(Rigidbody movingRigidbody)
        {
            _rigidbody = movingRigidbody;
            _startPosition = _rigidbody.transform.position;

            _directionContext = new DirectionContext(new DirectionRight());
        }

        public void StartMoving()
        {
            Move();
        }

        public void ResetMoving()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.transform.position = _startPosition;
        }

        public void SwitchDirection()
        {
            _directionContext.SwitchDirection();
            Move();
        }

        private void Move()
        {
            var oldVelocity = _rigidbody.velocity;
            var velocityInDirection = CurrentDirection * _speed;
            _rigidbody.velocity = new Vector3(velocityInDirection.x, oldVelocity.y, velocityInDirection.z);
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