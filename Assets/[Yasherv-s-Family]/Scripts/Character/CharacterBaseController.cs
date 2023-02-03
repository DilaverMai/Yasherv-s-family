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
            //TODO: MUCO
        }

        private void LookMouse()
        {
            var castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, GroundLayers))
            {
                var targetPoint = hit.point;
                targetPoint.y = Character.transform.position.y;
                Character.transform.LookAt(targetPoint);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void OnUpdate()
        {
            LookMouse();
            Move();
        }
    }
}

