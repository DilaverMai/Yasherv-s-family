using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YashervsFamaily.Scripts.Items
{
    public abstract class ItemBase : ScriptableObject
    {
        [field: SerializeField]public abstract SkillsEnum SkillType { get; }
        public abstract void ItemTriggerEnter(Collider other,ParticleSystem particleSystem, GameObject gameObject);
    }
}

