using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;

namespace YashervsFamaily.Scripts.Items
{
    [CreateAssetMenu (fileName = "Ice Item",menuName = "Collectable/Ice Item")]
    public class IceItem : ItemBase
    {
        public static Action OnIceCollectItem;

        public override void ItemTriggerEnter(Collider other, GameObject gameObject)
        {
            if (!other.TryGetComponent(out Player player)) return;
            OnIceCollectItem?.Invoke();
            gameObject.SetActive(false);
        }
    }
}


