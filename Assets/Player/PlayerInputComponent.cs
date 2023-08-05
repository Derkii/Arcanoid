using Pause;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputComponent : MonoBehaviour, IInput, IPausable
    {
        [SerializeField] private InputAction _movement;
        private bool _paused;

        public void SetPaused(bool value)
        {
            _paused = value;
        }


        public Vector3 Input
        {
            get
            {
                if (_paused) return Vector3.zero; 
                var input = _movement.ReadValue<Vector2>();
                return new Vector3(0, input.y, input.x);
            }
        }

        private void Start()
        {
            _movement.Enable();
        }

        private void OnDestroy()
        {
            _movement.Dispose();
        }

    }
}