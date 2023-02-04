using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using UnityEngine;

namespace YashervsFamaily.Scripts.Items
{
    [CreateAssetMenu (fileName = "Shake Item", menuName = "Collectable/Shake Item")]
    public class ShakeItem : ItemBase
    {
        public static Action OnShakeCollectItem;
        public override void ItemTriggerEnter(Collider other, GameObject gameObject)
        {
            if(!other.TryGetComponent(out Player player)) return;
            OnShakeCollectItem?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

