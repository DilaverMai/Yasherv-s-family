using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using Character;
using DG.Tweening;
using UnityEngine;

namespace YashervsFamaily.Scripts.Skills
{
    public class ShakeSkill : SkillBase
    {
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.radius = 0f;
        }

        public override void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(15);
            if(!other.TryGetComponent(out EnemyAnimation enemyAnimation)) return;
            enemyAnimation.ShakeAnimation(1f, Vector3.one * 0.45f);
            if (other.TryGetComponent(out IMoveable moveable))
                moveable.BackJump();
        }

        public void PlayAnimation()
        {
            DOTween.Kill("ShakeSkill");
            _collider.radius = 0f;
            DOTween.To(() => _collider.radius, x => _collider.radius = x, 3f, 0.4f).SetLoops(2,LoopType.Yoyo).SetId("ShakeSkill");
        }
        
    }
}

