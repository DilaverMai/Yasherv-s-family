using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

namespace _Yasherv_s_Family_.Scripts.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : CharacterBase
    {
        public CharacterBaseController<Player> Controller;

        private void Update()
        {
            Controller.OnUpdate();
        }

        public override void OnDeath()
        {
            
        }

        public override void OnSpawn()
        {
       
        }
    }
}