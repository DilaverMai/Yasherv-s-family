using System;
using System.Collections;
using System.Collections.Generic;
using _Yasherv_s_Family_.Scripts.Character;
using UnityEngine;

public class ShieldSkill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;
        //TODO Shild eklendiğinde..
    }
}
