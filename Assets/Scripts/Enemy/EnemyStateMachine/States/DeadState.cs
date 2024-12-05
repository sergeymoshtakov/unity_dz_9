using System.Collections;
using StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.EnemyStateMachine.States
{
    public class DeadState : AbstractState
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Enemy _enemy;

        private readonly int _deadStateHash = Animator.StringToHash("Idle");

        public override void StartState()
        {
            print($"{_enemy.gameObject.name} перешел в DeadState.");
            base.StartState();
            _animator.CrossFade(_deadStateHash, 0f);
            _enemy.gameObject.SetActive(false);
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}