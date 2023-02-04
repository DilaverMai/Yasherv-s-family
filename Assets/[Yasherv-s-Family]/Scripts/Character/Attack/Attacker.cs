using Character;
using UnityEngine;
using UnityEngine.Events;

namespace _Yasherv_s_Family_.Scripts.Character.Attack
{
    [System.Serializable]
    public class Attacker :MonoBehaviour, IAttackable,IInitializable
    {
        public AttackerData attackerData;
        public UnityAction OnAttack;
        
        public void Attack(Health health)
        {

        }

        public void Initialize()
        {
            
        }

        public void Attack(IDamageable damageable)
        {
            damageable.TakeDamage(attackerData.Damage);
            OnAttack?.Invoke();
        }
    }
}