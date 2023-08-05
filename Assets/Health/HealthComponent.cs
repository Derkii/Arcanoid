using System;
using UnityEngine;

namespace Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _startHealth;
        public event Action<int> OnHealthChanged;
        public int Health { get; private set; }

        private void Start()
        {
            Health = _startHealth;
            OnHealthChanged?.Invoke(_startHealth);
        }

        public void GetDamage(int damage)
        {
            if (damage < 0) throw new ArgumentException("Damage cannot be less than 0");
            
            Health -= damage;
            OnHealthChanged?.Invoke(Health);
        }
    }
}