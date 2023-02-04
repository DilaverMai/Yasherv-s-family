using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class ShieldDoor : DoorBase
{
    public override void OnEnable()
    {
        IceItem.OnIceCollectItem += OpenDoor;
    }

    public override void OnDisable()
    {
        IceItem.OnIceCollectItem -= OpenDoor;
    }
}
