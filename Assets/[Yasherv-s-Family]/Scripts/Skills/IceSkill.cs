using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

namespace YashervsFamaily.Scripts.Skills
{
    public class IceSkill : SkillBase
    {
        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            if(damageable.GetCharacterType is CharacterType.Player) return;
            damageable.TakeDamage(10);
            if(!other.TryGetComponent(out IMoveable move)) return;
            move.Stop();
        }
    }
}

