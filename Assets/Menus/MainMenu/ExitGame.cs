using UnityEngine;
using UnityEngine.UI;

namespace Menus.MainMenu
{
    public class ExitGame : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif !UNITY_EDITOR
                Application.Quit();
#endif
            });
        }
    }
}