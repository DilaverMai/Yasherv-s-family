using System;
using System.Collections;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using Character;
using Unity.VisualScripting;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

public class ShieldSkill : SkillBase
{
    private SphereCollider _collider;
    private ParticleSystem _particleSystem;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _collider = GetComponent<SphereCollider>();
        _collider.radius = 0f;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out IMoveable moveable)) return;
        moveable.BackJump();
    }
    
    public void StartFunction()
    {
        _particleSystem.Play();
        StartCoroutine(AfterDelay());
    }
    
    IEnumerator AfterDelay()
    {
        _collider.radius = 2.7f;
        yield return new WaitForSeconds(3f);
        _particleSystem.Stop();
        _collider.radius = 0f;
    }
    
    
}
