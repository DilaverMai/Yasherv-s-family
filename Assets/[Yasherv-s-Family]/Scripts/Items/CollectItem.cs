using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YashervsFamaily.Scripts.Items;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private ItemBase item;

    private void OnTriggerEnter(Collider other)
    {
        item.ItemTriggerEnter(other, this.gameObject);
    }
}
