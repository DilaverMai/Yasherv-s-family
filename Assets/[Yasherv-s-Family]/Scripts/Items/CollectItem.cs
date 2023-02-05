using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private ItemBase item;
    [SerializeField] private ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        item.ItemTriggerEnter(other, particleSystem, this.gameObject);
    }
}
