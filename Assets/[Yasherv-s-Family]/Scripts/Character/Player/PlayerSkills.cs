using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;
using YashervsFamaily.Scripts.Skills;

namespace YashervsFamaily.Scripts.Character.Player
{
    public class PlayerSkills : MonoBehaviour
    {
        [SerializeField] private _Yasherv_s_Family_.Scripts.Character.Player player;
        [SerializeField] private GameObject iceParticle;

        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform targetT;

        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                spawnPoint.transform.LookAt(targetT);
                var p = Instantiate(iceParticle, spawnPoint.position, spawnPoint.rotation);
                p.GetComponent<Rigidbody>().velocity = p.transform.TransformDirection(Vector3.forward * 20);
                print(player.GetCloseEnemies().Count);
                if(player.GetCloseEnemies().Count < 1) return;
                for (int i = 0; i < player.GetCloseEnemies().Count; i++)
                {
                    var particle = Instantiate(iceParticle);
                    var tempList = player.GetCloseEnemies();
                    particle.transform.LookAt(tempList[i].transform);
                    particle.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 20f);
                }
            }
        }
    }
}
