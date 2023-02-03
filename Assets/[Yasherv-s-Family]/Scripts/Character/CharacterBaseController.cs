using Character;
using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class CharacterBaseController<T>:IUpdater where T:CharacterBase
    {
        public T Character;
        public ContollerData ContollerData;
        public CharacterController _characterController;
        public LayerMask GroundLayers;

        
        public KeyCode MoveForward;
        public KeyCode MoveBack;
        public KeyCode MoveLeft;
        public KeyCode MoveRight;
        
        private void Move()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            var characterVector = new Vector3(horizontal, 0, vertical);
            _characterController.Move(characterVector);
            //Character.transform.TransformDirection(characterVector);
        }

        private void LookMouse()
        {
            var m_camera = Camera.main;
                var lookAtPos = Input.mousePosition;
            lookAtPos.z = Character.transform.position.z - m_camera.transform.position.z;
            lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
            Character.transform.up = lookAtPos - Character.transform.position;
            /*
            var castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (!Physics.Raycast(castPoint, out hit, Mathf.Infinity,GroundLayers)) return;
            
            var targetPoint = hit.point;
            targetPoint.y = Character.transform.position.y;
            Character.transform.LookAt(targetPoint);
            */
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void OnUpdate()
        {
            LookMouse();
            Move();
        }
    }
}