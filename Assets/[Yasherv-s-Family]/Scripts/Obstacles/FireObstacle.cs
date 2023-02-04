using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.SkillProgress;

public class FireObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerSkills playerSkills)) return;
        if (!other.TryGetComponent(out IDamageable damageable)) return;
        if (SkillManager.Instance.IsShieldCollected)
        {
            damageable.TakeDamage(0);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
