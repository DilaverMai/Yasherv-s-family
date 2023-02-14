using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Yasherv_s_Family_.Scripts.Character;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using YashervsFamaily.Scripts.Character.Player;

namespace Character
{
    [System.Serializable]
    public class CharacterBaseController<T>:IUpdater where T:CharacterBase
    {
        public T Character;
        public ContollerData ContollerData;
        public CharacterController _characterController;
        public Rigidbody _rigidbody;
        public KeyCode AttackKey;
        // public KeyCode SkillTwo;
        public KeyCode KeyDash;
        
        public LayerMask GroundLayer;
        private bool stopRotation;
        
        public PlayerAnimation _playerAnimation;
        private float extraSpeed;
        
        private Vector3 MoveVector()
        {
            return  new Vector3(Input.GetAxis("Horizontal"), -ContollerData.Gravity ,Input.GetAxis("Vertical"));
        }

        private void Move()
        {
            // _rigidbody.velocity = MoveVector() * (ContollerData.MoveSpeed  + extraSpeed);
            _characterController.Move(MoveVector() * ((ContollerData.MoveSpeed  + extraSpeed) * Time.fixedDeltaTime));
        }
        
        private void Rotation()
        {
            if(stopRotation) return;
            var moveRotation = MoveVector();
            moveRotation.y = 0;
            //rotation By Horizontal and Vertical
            if (!(moveRotation.magnitude > 0.1f)) return;
            
            var targetRotation = Quaternion.LookRotation(moveRotation);
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, targetRotation, ContollerData.RotationSpeed * Time.fixedDeltaTime);
        }
        
        private Vector3 RotationForSkill()
        {
            Debug.Log("RotationForSkill");
            stopRotation = true;
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            if (!Physics.Raycast(ray, out hit,100, GroundLayer)) return default;

            DOTween.Kill("RotationForSkill");
            var distance = (hit.point - Character.transform.position);
            distance.y = 0;
            var targetRotation = Quaternion.LookRotation(distance);
            Character.transform.DORotateQuaternion(targetRotation, 0.55f).OnComplete(
                ()=> stopRotation = false
                ).SetId("RotationForSkill");

            return targetRotation.eulerAngles;
        }
        
        private void UseSkillOne()
        {
            if (Input.GetKeyDown(AttackKey))
            {
                //await Task.Delay(1000);
                var card = DeckManager.Instance.SelectedCard;
                if(card == null) return;
              
                PlayerSkills.OnSkill.Invoke(card.SkillEnums,  RotationForSkill());
            }
            
            // if (Input.GetKeyDown(SkillOne))
            // {
            //     RotationForSkill();
            //     // _playerAnimation.PlayAnimation();
            //     //TODO: Use Skill One
            // }
            //
            // if (Input.GetKeyDown(SkillTwo))
            // {
            //     RotationForSkill();
            //     //TODO: Use Skill Two
            // }

            
            if (Input.GetKeyDown(KeyDash))
            {
                if(extraSpeed > 0) return;
                DashInTime();
            }
        }
        
         async void DashInTime()
        {
            extraSpeed = 20;
            await Task.Delay(150);
            extraSpeed = 0.1f;
            await Task.Delay(250);
            extraSpeed = 0f;
        }
         
        // ReSharper disable Unity.PerformanceAnalysis
        public void OnUpdate()
        {
            UseSkillOne();
        }


        public void OnFixedUpdate()
        {
            Rotation();
            Move();
        }
    }
}

