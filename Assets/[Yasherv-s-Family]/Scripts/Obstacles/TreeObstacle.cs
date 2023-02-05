using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

public class TreeObstacle : MonoBehaviour
{
    private float health = 100;
    [SerializeField] private GameObject obstacle;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out FireSkill fireSkill)) return;
        health -= 20f;
        if(health > 0.1) return;
        obstacle.SetActive(false);
    }
    
}
