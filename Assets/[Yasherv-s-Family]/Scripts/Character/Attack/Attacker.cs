using System;
using System.Collections;
using Character;
using UnityEngine;
using UnityEngine.Events;

namespace _Yasherv_s_Family_.Scripts.Character.Attack
{
    [System.Serializable]
    public class Attacker :MonoBehaviour, IAttackable
    {
        public int damage;
        public float attackSpeed;
        public UnityAction OnAttack;
        private Coroutine _attackCoroutine;
        private IDamageable _damageable;

        private void Start()
        {
            StartCoroutine(AttackIEnumerator());
        }

        IEnumerator AttackIEnumerator()
        {
            while (true)
            {
                yield return new WaitUntil(()=> _damageable != null);
                _damageable.TakeDamage(damage);
                OnAttack?.Invoke();
                yield return new WaitForSeconds(attackSpeed);
            }
            
        }
        
        public void Attack(IDamageable damageable)
        {
            _damageable = damageable;
        }
    }
}