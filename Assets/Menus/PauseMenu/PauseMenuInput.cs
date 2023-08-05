using TNRD;
using UnityEngine;
using VContainer;

namespace Menus.PauseMenu
{
    public class PauseMenuInput : MonoBehaviour
    {
        [SerializeField] private SerializableInterface<IKeyInput> _keyInput;
        [Inject] private PauseMenuData _pauseMenu;
        private void Start()
        {
            _keyInput.Value.Performed += _pauseMenu.Open;
        }

        private void OnDestroy()
        {
            _keyInput.Value.Performed -= _pauseMenu.Open;
        }
    }
}