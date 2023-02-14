using Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Yasherv_s_Family_.Scripts.Character
{
    public class AttackTrigger : MonoBehaviour
    { 
        private IAttackable attacker;
        public CharacterType targetCharacterType;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDamageable>(out var damageable)) return;
            if (damageable.GetCharacterType != targetCharacterType) return;
            attacker.Attack(damageable);
        }
    }
}