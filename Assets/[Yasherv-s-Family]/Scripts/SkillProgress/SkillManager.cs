using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.Skills;

namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillManager : MonoBehaviour
    {

        [SerializeField] private List<Collider2D> checkOverlay = new();
        [SerializeField] private GameObject qSkill;
        [SerializeField] private GameObject eSkill;

        [SerializeField] private LayerMask layerMask;
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

