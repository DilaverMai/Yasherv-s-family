using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using _Yasherv_s_Family_.Scripts.Character.Player;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

[CreateAssetMenu (fileName = "Fire Item", menuName = "Collectable/Fire Item")]
public class FireItem : ItemBase
{
    public static Action OnFireCollectItem;
    public override SkillsEnum SkillType { get => SkillsEnum.Fire; }
    

    public override void ItemTriggerEnter(Collider other,GameObject gameObject)
    {
        if (!other.TryGetComponent(out Player player)) return;
        OnFireCollectItem?.Invoke();
        gameObject.SetActive(false);
    }
}
