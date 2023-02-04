using System;
using Character;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace _Yasherv_s_Family_.Scripts.Character
{
    public enum EnemyAnimations
    {
        Idle,
        Walk,
        Attack,
        Hit,
        Death
    }

    public class EnemyAnimation : CharacterAnimation<EnemyAnimations>
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public Tween ShakeAnimation(float time,Vector3 strength)
        {
            DOTween.Kill("ShakeAnimation" + gameObject.GetInstanceID());
            return transform.DOShakeScale(time, strength).SetId("ShakeAnimation" + gameObject.GetInstanceID());
        }

        private void Update()
        {
            SetSpeed();
        }

        public override void SetSpeed(float speed = 0)
        {
            base.SetSpeed(_navMeshAgent.velocity.magnitude);
        }
    }
}