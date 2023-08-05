using Health;
using Player;
using UnityEngine;

namespace Game
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private BallController _player;
        [SerializeField] private HealthComponent _playerHealth;

        private void OnCollisionEnter(Collision collision)
        {
            var ball = collision.gameObject.GetComponent<Ball>();
            if (ball == null) return;
            _playerHealth.GetDamage(_damage);
            _player.SetBallControlling(true);
            ball.ResetSpeed();
        }
    }
}