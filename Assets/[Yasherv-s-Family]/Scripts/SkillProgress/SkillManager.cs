using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YashervsFamaily.Scripts.Items;


namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillManager : Singleton<SkillManager>
    {
        private const string KeyIceCollected = "KEY_ICE_COLLECTED";
        private const string KeyFireCollected = "KEY_FIRE_COLLECTED";
        private const string KeyShakeCollected = "KEY_SHAKE_COLLECTED";
        private const string KeyShieldCollected = "KEY_SHIELD_COLLECTED";
        private const string KeyDashCollected = "KEY_DASH_COLLECTED";
        public bool IsIceCollected;

        public bool IsFireCollected;

        public bool IsShakeCollected;

        public bool IsShieldCollected;

        public bool IsDashCollected;
        
        private void OnEnable()
        {
            IceItem.OnIceCollectItem += SetIceCollected;
            FireItem.OnFireCollectItem += SetFireCollected;
            ShakeItem.OnShakeCollectItem += SetShakeCollected;
            ShieldItem.OnShieldCollectItem += SetShieldCollected;
        }

        private void OnDisable()
        {
            IceItem.OnIceCollectItem -= SetIceCollected;
            FireItem.OnFireCollectItem -= SetFireCollected;
            ShakeItem.OnShakeCollectItem -= SetShakeCollected;
            ShieldItem.OnShieldCollectItem -= SetShieldCollected;
        }

        private void SetIceCollected()
        {
            IsIceCollected = true;
        }

        private void SetFireCollected()
        {
            IsFireCollected = true;
        }

        private void SetShakeCollected()
        {
            IsShakeCollected = true;
        }

        private void SetShieldCollected()
        {
            IsShieldCollected = true;
            print("Collected");
        }
    }
}