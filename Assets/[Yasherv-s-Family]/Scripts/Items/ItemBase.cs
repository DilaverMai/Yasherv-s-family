using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YashervsFamaily.Scripts.Items
{
    public abstract class ItemBase : ScriptableObject
    {
        public abstract void ItemTriggerEnter(Collider other, GameObject gameObject);
    }
}

