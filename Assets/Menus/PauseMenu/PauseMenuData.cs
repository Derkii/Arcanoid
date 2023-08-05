using Pause;
using UnityEngine;
using VContainer;

namespace Menus.PauseMenu
{
    public class PauseMenuData : MonoBehaviour
    {
        [SerializeField] private Transform _panelTransform;
        [SerializeField] private Vector2 _openedPanelScale;
        [SerializeField] private OpenMenu _openMenu;
        [SerializeField] private ReturnToGame _returnToGame;
        [Inject] private PauseManager _pauseManager;

        public bool IsClosing
        {
            get => _returnToGame.IsClosing;
        }

        public bool IsOpening
        {
            get => _openMenu.IsOpening;
        }

        public Transform PanelTransform => _panelTransform;
        public Vector2 OpenedPanelScale => _openedPanelScale;

        [ContextMenu("Use current scale as opened panel scale")]
        private void UseCurrentScale()
        {
            _openedPanelScale = _panelTransform.localScale;
        }

        public void Open()
        {
            _pauseManager.Pause(true);
            _openMenu.Open();
        }

        public void Close()
        {
            _returnToGame.Close(() => _pauseManager.Pause(false));
        }
    }
}