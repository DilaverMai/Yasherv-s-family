using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;
using YashervsFamaily.Scripts.SkillProgress;

public class SpikeObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerSkills playerSkills)) return;
        if (!other.TryGetComponent(out IDamageable damageable)) return;
        if (SkillManager.Instance.IsShieldCollected)
        {
            playerSkills.shieldParticle.GetComponent<ParticleSystem>().Play();
            return;
        }
        damageable.TakeDamage(1000);
    }
}
