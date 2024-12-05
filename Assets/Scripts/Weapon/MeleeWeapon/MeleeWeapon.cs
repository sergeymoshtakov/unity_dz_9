using UnityEngine;

namespace Weapon.MeleeWeapon
{
    public class MeleeWeapon : Weapon
    {
        [SerializeField] private float _attackRadius;

        [SerializeField] private float _damage;

        protected override void Attack()
        {
            if (PlayerInput.AttackInput)
            {
                var colliders = Physics.OverlapSphere(transform.position, _attackRadius);

                foreach (var collider in colliders)
                {
                    if (collider.TryGetComponent(out Enemy.Health enemyHealth))
                    {
                        enemyHealth.TakeDamage(_damage);
                        print($"Ударили {enemyHealth.name} на {_damage} урона.");
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
    }
}