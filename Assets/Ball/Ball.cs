using Pause;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Movement))]
    public class Ball : MonoBehaviour, IInput, IPausable
    {
        [SerializeField] private float _startSpeed, _additionalSpeed, _maxSpeed;

        private Movement _movement;
        private Vector3 _direction;
        private Rigidbody _rigidBody;
        private bool _isPlayerControlling;
        public Vector3 Input => _paused ? Vector3.zero : _direction;
        private bool _paused;

        private struct Frame
        {
            private float _min, _max;
            public float Min => _min;
            public float Max => _max;

            public Frame(float min, float max)
            {
                _min = min;
                _max = max;
            }

            public float Randomize() => Random.Range(_min, _max);
        }

        public void SetPaused(bool value)
        {
            _paused = value;
            _rigidBody.constraints =
                value
                    ? _rigidBody.constraints |
                      RigidbodyConstraints.FreezePosition
                    : _isPlayerControlling
                        ? _rigidBody.constraints
                        : _rigidBody.constraints ^ RigidbodyConstraints.FreezePosition;
        }

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _movement = GetComponent<Movement>();
            _movement.SetManualUpdateMode(true);
            _movement.Speed = _startSpeed;
            _direction = Vector3.down;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isPlayerControlling) return;
            var frame = new Frame(-0.1f, 0.1f);
            var randomVector3 = RandomVector3(
                frame,
                frame,
                frame);
            _direction = (Vector3.Reflect(_direction, collision.GetContact(0).normal) +
                          randomVector3
                ).normalized;

            Debug.Log(_direction.y);
            Debug.Log(randomVector3.y);
        }

        private Vector3 RandomVector3(Frame xFrame, Frame yFrame, Frame zFrame)
        {
            float Range(Frame frame) =>
                    Random.Range(frame.Min, frame.Max);


            var x = Range(xFrame);
            var y = Range(yFrame);
            var z = Range(zFrame);
            return new Vector3(x, y, z);
        }

        private void Update()
        {
            if (_isPlayerControlling || _paused) return;
            _movement.Move();
        }

        public void SetBallControlByPlayer(bool state, Transform playerTransform)
        {
            if (state)
            {
                _rigidBody.constraints |= RigidbodyConstraints.FreezePosition;
                transform.parent = playerTransform;
                transform.localPosition = new Vector3(0f, 0f, 1f);
            }
            else
            {
                if (!_isPlayerControlling) return;
                _rigidBody.constraints ^= RigidbodyConstraints.FreezePosition;
                _direction = playerTransform.forward;
                transform.parent = null;
            }

            _isPlayerControlling = state;
        }

        public void ResetSpeed()
        {
            _movement.Speed = _startSpeed;
            _movement.Speed = Mathf.Clamp(_movement.Speed, _startSpeed, _maxSpeed);
        }

        public void AddSpeed()
        {
            _movement.Speed += _additionalSpeed;
            _movement.Speed = Mathf.Clamp(_movement.Speed, _startSpeed, _maxSpeed);
        }
    }
}