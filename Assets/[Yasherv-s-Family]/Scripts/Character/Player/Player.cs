using Character;
using UnityEngine;

namespace _Yasherv_s_Family_.Scripts.Character.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : CharacterBase
    {
        public CharacterBaseController<Player> Controller;

        private void Update()
        {
            Controller.OnUpdate();
        }

        private void FixedUpdate()
        {
            Controller.OnFixedUpdate();
        }

        public override void OnDeath()
        {
            
        }

        public override void OnSpawn()
        {
       
        }
    }
}