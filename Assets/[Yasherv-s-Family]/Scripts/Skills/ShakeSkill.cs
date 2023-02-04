using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using Character;
using UnityEngine;

namespace YashervsFamaily.Scripts.Skills
{
    public class ShakeSkill : SkillBase
    {
        public override void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(15);
            if(!other.TryGetComponent(out EnemyAnimation enemyAnimation)) return;
            enemyAnimation.ShakeAnimation(1f, Vector3.one * 1.3f);
        }
    }
}

