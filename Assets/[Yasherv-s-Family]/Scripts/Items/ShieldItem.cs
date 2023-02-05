using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;

namespace YashervsFamaily.Scripts.Items
{
    [CreateAssetMenu (fileName = "Shield Item", menuName = "Collectable/Shield Item")]
    public class ShieldItem : ItemBase
    {
        public static Action OnShieldCollectItem;
        public override SkillsEnum SkillType { get => SkillsEnum.Shield; }

        public override void ItemTriggerEnter(Collider other,ParticleSystem particleSystem, GameObject gameObject)
        {
            if(!other.TryGetComponent(out Player player)) return;
            OnShieldCollectItem?.Invoke();
            particleSystem.Stop();
            BallManager.OnSkill?.Invoke(SkillType);
            gameObject.SetActive(false);
        }
    }
}

