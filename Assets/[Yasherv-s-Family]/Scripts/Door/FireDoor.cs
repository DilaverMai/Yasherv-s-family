using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class FireDoor : DoorBase
{
    public override void OnEnable()
    {
        ShakeItem.OnShakeCollectItem += OpenDoor;
    }

    public override void OnDisable()
    {
        ShakeItem.OnShakeCollectItem -= OpenDoor;
    }
}
