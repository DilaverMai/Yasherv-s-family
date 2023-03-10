using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;
using YashervsFamaily.Scripts.SkillProgress;

namespace YashervsFamaily.Scripts.Items
{
    [CreateAssetMenu (fileName = "Shake Item", menuName = "Collectable/Shake Item")]
    public class ShakeItem : ItemBase
    {
        public static Action OnShakeCollectItem;
        public override SkillsEnum SkillType { get => SkillsEnum.Earth; }

        public override void ItemTriggerEnter(Collider other,ParticleSystem particleSystem, GameObject gameObject)
        {
            if(!other.TryGetComponent(out Player player)) return;
            OnShakeCollectItem?.Invoke();
            particleSystem.Stop();
            BallManager.OnSkill?.Invoke(SkillType);
            SpeechManager.SpeechGirl.Invoke(2);

            gameObject.SetActive(false);
        }
    }
}

