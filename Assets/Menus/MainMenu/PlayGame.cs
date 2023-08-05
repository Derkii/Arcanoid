using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus.MainMenu
{
    public class PlayGame : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;

        private void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Game");
            });
        }
    }
}