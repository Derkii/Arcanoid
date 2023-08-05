using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using VContainer;

namespace Menus.PauseMenu
{
    public class ReturnToGame : MonoBehaviour
    {
        [SerializeField] private float _time;
        [Inject] private PauseMenuData _pauseMenu;
        public bool IsClosing { get; private set; }

        public void Close(Action after)
        {
            ClosePanel(after);
        }
        private async UniTaskVoid ClosePanel(Action after)
        {
            if (IsClosing || _pauseMenu.IsOpening) return;

            IsClosing = true;
            await _pauseMenu.PanelTransform.DOScale(Vector3.zero, _time).AsyncWaitForCompletion();
            _pauseMenu.PanelTransform.gameObject.SetActive(false);
            IsClosing = false;
            after.Invoke();
        }
    }
}