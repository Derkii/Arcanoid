using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Menus.PauseMenu
{
    public class KeyInput : MonoBehaviour, IKeyInput
    {
        [SerializeField]
        private InputAction _key;
        public event Action Performed;
        private void Awake()
        {
            _key.Enable();
            _key.performed += _ => Performed?.Invoke();
        }

        private void OnDestroy()
        {
            _key.Disable();
            _key.Dispose();
        }
    }

    public interface IKeyInput
    {
        public event Action Performed;
    }
}