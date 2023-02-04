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
        
        private Vector3 MoveVector()
        {
            return  new Vector3(Input.GetAxis("Horizontal"), -ContollerData.Gravity * Time.deltaTime,Input.GetAxis("Vertical"));
        }
        
        private void Move()
        {
            _characterController.Move(MoveVector() * ContollerData.MoveSpeed * Time.deltaTime);
        }
        
        private void Rotation()
        {
            var moveRotation = MoveVector();
            moveRotation.y = 0;
            //rotation By Horizontal and Vertical
            if (!(moveRotation.magnitude > 0.1f)) return;
            
            var targetRotation = Quaternion.LookRotation(moveRotation);
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, targetRotation, 0.75f);
        }
        
        private void RotationForSkill()
        {
            var moveRotation = MoveVector();
            moveRotation.y = 0;
            //rotation By Horizontal and Vertical
            if (!(moveRotation.magnitude > 0.1f)) return;
            
            var targetRotation = Quaternion.LookRotation(moveRotation);
            Character.transform.rotation = Quaternion.Lerp(Character.transform.rotation, targetRotation, 0.75f);
        }
        
        private void UseSkillOne()
        {
            if (Input.GetKeyDown(SkillOne))
            {
                //TODO: Use Skill One
            }

            if (Input.GetKeyDown(SkillTwo))
            {
                //TODO: Use Skill Two
            }
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

