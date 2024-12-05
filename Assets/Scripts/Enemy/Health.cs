using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth = 10f;
        private float _currentHealth;

        public bool IsDead => _currentHealth <= 0;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;
            print("Current health: " + _currentHealth);

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            var deadState = GetComponentInParent<EnemyStateMachine.States.DeadState>();
            if (deadState != null)
            {
                deadState.StartState();
            }
        }
    }
}
