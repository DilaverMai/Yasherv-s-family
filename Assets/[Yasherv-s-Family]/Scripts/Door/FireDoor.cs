using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class FireDoor : DoorBase
{
    [SerializeField] private GameObject fireParticle;
    public override void OnEnable()
    {
        ShakeItem.OnShakeCollectItem += OpenDoor;
    }

    public override void OnDisable()
    {
        ShakeItem.OnShakeCollectItem -= OpenDoor;
    }

    public override void OpenDoor()
    {
        base.OpenDoor();
        fireParticle.SetActive(true);
    }
}
