using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace YashervsFamaily.Scripts.SkillProgress
{
    public class SkillProgress : MonoBehaviour
    {
        [SerializeField] private Button[] skills;
        [SerializeField] private Transform[] skillPoints;

        private readonly WaitForSeconds _duration = new(1f);

        private void Start()
        {
            StartCoroutine(TrySkillsSpawn());
        }

        private IEnumerator TrySkillsSpawn()
        {
            while (true)
            {
                yield return _duration;
                for (int i = 0; i < 2; i++)
                {
                    var skill = Instantiate(skills[Random.Range(0, skills.Length)], skillPoints[i].position,
                        Quaternion.identity);
                }
                
            }
        }
    }
}

