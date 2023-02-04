using System;
using Character;
using UnityEngine;

namespace _Yasherv_s_Family_.Scripts.Character
{
    public enum PlayerAnimations
    {
        Idle,
        Walk,
        Run,
        Attack,
        Death,
    }
    public class PlayerAnimation : CharacterAnimation<PlayerAnimations>
    {
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
           SetSpeed();
        }

        public override void SetSpeed(float speed = 0)
        {
            base.SetSpeed(_characterController.velocity.magnitude);
        }
    }
}