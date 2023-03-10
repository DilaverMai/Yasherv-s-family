using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

namespace YashervsFamaily.Scripts.Skills
{
    public class IceSkill : SkillBase
    {
        public ParticleSystem hitParticle;
        private Collider _collider;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }
        public override void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            if(damageable.GetCharacterType is CharacterType.Player) return;
            _rigidbody.velocity = Vector3.zero;
            _collider.enabled = false;
            hitParticle.Play();

            damageable.TakeDamage(10);
            if(!other.TryGetComponent(out IMoveable move)) return;
            move.StopAndStartDelay(2f);
        }
    }
}

