using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus.PauseMenu
{
    public class ReturnToMainMenu : MonoBehaviour
    {
        [SerializeField] private Button _returnButton;

        private void Start()
        {
            _returnButton.onClick.AddListener(ReturnButtonAction);
        }

        private void ReturnButtonAction()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
