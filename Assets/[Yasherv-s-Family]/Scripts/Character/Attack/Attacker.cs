using System.Collections;
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
        private Coroutine _attackCoroutine;
        
        public void Initialize()
        {
            
        }
        
        IEnumerator AttackIEnumerator(IDamageable damageable)
        {
            while (damageable != null)
            {
                damageable.TakeDamage(attackerData.Damage);
                OnAttack?.Invoke();
                yield return new WaitForSeconds(attackerData.AttackSpeed);
            }
            
            _attackCoroutine = null;
        }
        
        public void Attack(IDamageable damageable)
        {
            if(_attackCoroutine != null) return;
            _attackCoroutine=StartCoroutine(AttackIEnumerator(damageable));
        }
    }
}