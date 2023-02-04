using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class ShakeDoor : DoorBase
{
    [SerializeField] private GameObject fireParticle;
    public override void OnEnable()
    {
        ShieldItem.OnShieldCollectItem += OpenDoor;
    }

    public override void OnDisable()
    {
        ShieldItem.OnShieldCollectItem -= OpenDoor;
    }

    public override void OpenDoor()
    {
        base.OpenDoor();
        fireParticle.SetActive(true);
    }
}
