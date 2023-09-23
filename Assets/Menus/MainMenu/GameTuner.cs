using UnityEngine;

namespace Menus.MainMenu
{
    public class GameTuner : MonoBehaviour
    {
        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 150;
        }
    }
}
