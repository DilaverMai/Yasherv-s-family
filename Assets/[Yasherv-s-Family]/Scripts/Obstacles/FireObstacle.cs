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
        print("Deneme");
        if (!other.TryGetComponent(out PlayerSkills playerSkills)) return;
        print("Player Skill");
        if (!other.TryGetComponent(out IDamageable damageable)) return;
        print("Damage");
        if (SkillManager.Instance.IsShieldCollected)
        {
            print("true");
            damageable.TakeDamage(0);
            playerSkills.shieldParticle.SetActive(true);
            return;
        }
        print("false");
        damageable.TakeDamage(10);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent(out PlayerSkills playerSkills)) return;
        if (!other.TryGetComponent(out IDamageable damageable)) return;
        if (!SkillManager.Instance.IsShieldCollected) return;
        damageable.TakeDamage(0);
        playerSkills.shieldParticle.SetActive(false);
    }
}
