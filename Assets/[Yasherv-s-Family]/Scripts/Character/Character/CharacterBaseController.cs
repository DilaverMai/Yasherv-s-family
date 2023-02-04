using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Yasherv_s_Family_.Scripts.Character;
using DG.Tweening;
using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class CharacterBaseController<T>:IUpdater where T:CharacterBase
    {
        public T Character;
        public ContollerData ContollerData;
        public CharacterController _characterController;

        public KeyCode SkillOne;
        public KeyCode SkillTwo;
        public KeyCode KeyDash;
        
        public LayerMask GroundLayer;
        private bool stopRotation;
        
        public PlayerAnimation _playerAnimation;
        private float extraSpeed;
        
        private Vector3 MoveVector()
        {
            return  new Vector3(Input.GetAxis("Horizontal"), -ContollerData.Gravity * Time.deltaTime,Input.GetAxis("Vertical"));
        }
        
        private void Move()
        {
            _characterController.Move(MoveVector() * (ContollerData.MoveSpeed  + extraSpeed) * Time.deltaTime);
        }
        
        private void Rotation()
        {
            if(stopRotation) return;
            var moveRotation = MoveVector();
            moveRotation.y = 0;
            //rotation By Horizontal and Vertical
            if (!(moveRotation.magnitude > 0.1f)) return;
            
            var targetRotation = Quaternion.LookRotation(moveRotation);
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, targetRotation, 0.55f);
        }
        
        private void RotationForSkill()
        {
            Debug.Log("RotationForSkill");
            stopRotation = true;
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit, GroundLayer)) return;

            DOTween.Kill("RotationForSkill");
            var targetRotation = Quaternion.LookRotation(hit.point - Character.transform.position);
            Character.transform.DORotateQuaternion(targetRotation, 0.35f).OnComplete(
                ()=> stopRotation = false
                ).SetId("RotationForSkill");
        }
        
        private void UseSkillOne()
        {
            if (Input.GetKeyDown(SkillOne))
            {
                RotationForSkill();
                // _playerAnimation.PlayAnimation();
                //TODO: Use Skill One
            }

            if (Input.GetKeyDown(SkillTwo))
            {
                RotationForSkill();
                //TODO: Use Skill Two
            }

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
            Move();
            Rotation();
            UseSkillOne();
        }


    }
}

