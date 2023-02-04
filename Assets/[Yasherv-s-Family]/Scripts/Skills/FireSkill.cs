using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

namespace YashervsFamaily.Scripts.Skills
{ 
    public class FireSkill : SkillBase
    {
        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            if(damageable.GetCharacterType is CharacterType.Player) return;
            damageable.TakeDamage(10);
        }
    }
}

