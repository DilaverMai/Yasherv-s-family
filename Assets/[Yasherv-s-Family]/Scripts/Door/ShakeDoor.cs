using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class ShakeDoor : DoorBase
{
    public override void OnEnable()
    {
        ShieldItem.OnShieldCollectItem += OpenDoor;
    }

    public override void OnDisable()
    {
        ShieldItem.OnShieldCollectItem -= OpenDoor;
    }
}
