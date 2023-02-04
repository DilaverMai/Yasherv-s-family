using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillManager : MonoBehaviour
    {

        public static SkillManager Instance;
        
        [SerializeField] private List<Collider2D> checkOverlay = new();
        [SerializeField] private GameObject qSkill;
        [SerializeField] private GameObject eSkill;

        [SerializeField] private LayerMask layerMask;


        private const string KEY_ICE_COLLECTED = "Key_Ice_Collected";
        private const string KEY_FIRE_COLLECTED = "Key_Fire_Collected";
        private const string KEY_SHAKE_COLLECTED = "Key_Shake_Collected";
        private const string KEY_SHIELD_COLLECTED = "Key_Shield_Collected";
        private const string KEY_DASH_COLLECTED = "Key_Dash_Collected";
        public bool IsIceCollected
        {
            get => ES3.Load(KEY_ICE_COLLECTED, false);
            set => ES3.Save(KEY_ICE_COLLECTED, value);
        }

        public bool IsFireCollected
        {
            get => ES3.Load(KEY_FIRE_COLLECTED, false);
            set => ES3.Save(KEY_FIRE_COLLECTED, value);
        }

        public bool IsShakeCollected
        {
            get => ES3.Load(KEY_SHAKE_COLLECTED, false);
            set => ES3.Save(KEY_SHAKE_COLLECTED, value);
        }

        public bool IsShieldCollected
        {
            get => ES3.Load(KEY_SHIELD_COLLECTED, false);
            set => ES3.Save(KEY_SHIELD_COLLECTED, value);
        }

        public bool IsDashCollected
        {
            get => ES3.Load(KEY_DASH_COLLECTED, false);
            set => ES3.Save(KEY_DASH_COLLECTED, value);
        }
    }
}

