using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Menus.PauseMenu
{
    public class ReturnToGameButton : MonoBehaviour
    {
        [Inject] private PauseMenuData _menu;
        [SerializeField] private Button _returnButton;

        private void Start()
        {
            _returnButton.onClick.AddListener(_menu.Close);
        }
    }
}