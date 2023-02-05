using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private ItemBase item;
    [SerializeField] private ParticleSystem particleSystem;
    public int speechIndex;
    private void OnTriggerEnter(Collider other)
    {
        item.ItemTriggerEnter(other, particleSystem, this.gameObject);
    }
}
