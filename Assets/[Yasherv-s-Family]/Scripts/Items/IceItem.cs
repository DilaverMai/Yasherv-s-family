using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;
using YashervsFamaily.Scripts.SkillProgress;

namespace YashervsFamaily.Scripts.Items
{
    [CreateAssetMenu (fileName = "Ice Item",menuName = "Collectable/Ice Item")]
    public class IceItem : ItemBase
    {
        public static Action OnIceCollectItem;
        public override SkillsEnum SkillType { get => SkillsEnum.Ice; }

        public override void ItemTriggerEnter(Collider other,ParticleSystem particleSystem, GameObject gameObject)
        {
            if (!other.TryGetComponent(out Player player)) return;
            OnIceCollectItem?.Invoke();
            particleSystem.Stop();
            BallManager.OnSkill?.Invoke(SkillType);
            SpeechManager.SpeechGirl.Invoke(3);
            gameObject.SetActive(false);
            
        }
    }
}


