using Game;
using Menus.PauseMenu;
using UnityEngine;

namespace Player
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private KeyInput _keyInput;
        
        private void Start()
        {
            _keyInput.Performed += () => SetBallControlling(false);
            SetBallControlling(true);
        }

        public void SetBallControlling(bool state)
        {
            _ball.SetBallControlByPlayer(state, transform);
        }
    }
}