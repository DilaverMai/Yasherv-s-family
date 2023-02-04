using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillManager : Singleton<SkillManager>
    {
        [SerializeField] private List<Collider2D> checkOverlay = new();
        [SerializeField] private GameObject qSkill;
        [SerializeField] private GameObject eSkill;

        [SerializeField] private LayerMask layerMask;

        public static Action OnSkillUsed;
        public static Action OnSkillKeyPressed;

        public bool IsIce;
        public bool IsFire;
        public bool IsShake;
        public bool IsShield;
        public bool IsDash;
        
        

        private void FixedUpdate()
        {
            checkOverlay = Physics2D.OverlapBoxAll(transform.position,Vector2.one * 50, layerMask).ToList();
            if(!IsSkillActive()) return;
            qSkill = checkOverlay[0].gameObject;
            eSkill = checkOverlay[1].gameObject;
        }

        private void Update()
        {
            if (!IsSkillActive()) return;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
        private bool IsSkillActive()
        {
            return checkOverlay.Count > 1;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position,Vector2.one * 50);
        }
    }
}