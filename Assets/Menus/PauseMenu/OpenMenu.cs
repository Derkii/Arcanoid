using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace Menus.PauseMenu
{
    public class OpenMenu : MonoBehaviour
    {
        [SerializeField] private float _time;
        [Inject] private PauseMenuData _pauseMenu;
        public bool IsOpening { get; private set; }

        public void Open()
        {
            OpenPanel();
        }

        private async UniTaskVoid OpenPanel()
        {
            if (IsOpening || _pauseMenu.IsClosing) return;
            _pauseMenu.PanelTransform.localScale = Vector3.zero;
            _pauseMenu.PanelTransform.gameObject.SetActive(true);
            IsOpening = true;
            await _pauseMenu.PanelTransform.DOScale(_pauseMenu.OpenedPanelScale, _time).AsyncWaitForCompletion();
            IsOpening = false;
        }
    }
}