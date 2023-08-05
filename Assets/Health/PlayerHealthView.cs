using TMPro;
using UnityEngine;

namespace Health
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private HealthComponent _player;
        [SerializeField] private TextMeshProUGUI _livesText;

        private void Start()
        {
            _livesText.text = _player.Health.ToString();
            _player.OnHealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int lives)
        {
            _livesText.text = lives.ToString();

            if (lives > 0) return;
            Debug.Log("You lose");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = true;
#elif !UNITY_EDITOR
                Application.Quit();
#endif
        }

        private void OnDestroy()
        {
            _player.OnHealthChanged -= OnHealthChanged;
        }
    }
}