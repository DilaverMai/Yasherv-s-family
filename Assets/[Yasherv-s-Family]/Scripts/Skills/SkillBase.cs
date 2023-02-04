using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YashervsFamaily.Scripts.Skills
{
    public abstract class SkillBase : MonoBehaviour
    { 
        public abstract void OnTriggerEnter(Collider other);
    }
}

