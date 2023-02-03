using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YashervsFamaily.Scripts.Skills
{
    public class ShakeSkill : SkillBase
    {
        public static Action OnShakeSkill;
        
        public override void Skill()
        {
            OnShakeSkill?.Invoke();
        }
    }
}

