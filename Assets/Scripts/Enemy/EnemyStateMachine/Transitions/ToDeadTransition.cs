using StateMachine;
using UnityEngine;

namespace Enemy.EnemyStateMachine.Transitions
{
    public class ToDeadTransition : AbstractTransition
    {
        [SerializeField] private Health _health;

        private void Update()
        {
            if (_health.IsDead)
            {
                ShouldTransition = true;
            }
        }
    }
}