using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using DG.Tweening;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

public class TreeObstacle : MonoBehaviour
{
    private float health = 100;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out FireSkill fireSkill)) return;
        health -= 20f;
        obstacle.transform.DOShakeScale(1f, 1.2f);
        if(health > 0.1) return;

        obstacle.SetActive(false);
        collider.enabled = false;
    }
    
}
