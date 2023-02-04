using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using Cinemachine;
using UnityEngine;

public static class ExtensionMethods
{
    public static List<EnemyBase> GetCloseEnemies(this _Yasherv_s_Family_.Scripts.Character.Player player)
    {
        var results = Physics.OverlapSphere(player.transform.position, 5f);
        var enemies = new List<EnemyBase>();
        foreach (var item in results)
        {
            if (item.TryGetComponent(out EnemyBase enemyBase))
            {
                enemies.Add(enemyBase);
            }
        }

        return enemies;
    }

    public static IEnumerator CameraTransfer(this CinemachineVirtualCamera mainCamera,
        CinemachineVirtualCamera nextCamera, float duration)
    {
        mainCamera.Priority = 0;
        nextCamera.Priority = 11;
        yield return new WaitForSeconds(duration);
        mainCamera.Priority = 10;
        nextCamera.Priority = 0;
    }
}