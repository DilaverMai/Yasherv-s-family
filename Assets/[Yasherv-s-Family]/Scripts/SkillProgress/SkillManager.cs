using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YashervsFamaily.Scripts.Items;


namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillManager : Singleton<SkillManager>
    {

        public static Action OnSkillUsed;
        public static Action OnSkillKeyPressed;

        private const string KeyIceCollected = "KEY_ICE_COLLECTED";
        private const string KeyFireCollected = "KEY_FIRE_COLLECTED";
        private const string KeyShakeCollected = "KEY_SHAKE_COLLECTED";
        private const string KeyShieldCollected = "KEY_SHIELD_COLLECTED";
        private const string KeyDashCollected = "KEY_DASH_COLLECTED";
        public bool IsIceCollected
        {
            get => ES3.Load(KeyIceCollected, false);
            set => ES3.Save(KeyIceCollected, value);
        }

        public bool IsFireCollected
        {
            get => ES3.Load(KeyFireCollected, false);
            set => ES3.Save(KeyFireCollected, value);
        }

        public bool IsShakeCollected
        {
            get => ES3.Load(KeyShakeCollected, false);
            set => ES3.Save(KeyShakeCollected, value);
        }

        public bool IsShieldCollected
        {
            get => ES3.Load(KeyShieldCollected, false);
            set => ES3.Save(KeyShieldCollected, value);
        }

        public bool IsDashCollected
        {
            get => ES3.Load(KeyDashCollected, false);
            set => ES3.Save(KeyDashCollected, value);
        }
        
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
        }
    }
}