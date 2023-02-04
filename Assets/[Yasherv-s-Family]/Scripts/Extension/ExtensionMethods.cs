using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

public static class ExtensionMethods
{
    public static List<EnemyBase> GetCloseEnemies(this _Yasherv_s_Family_.Scripts.Character.Player player)
    {
        var results = new Collider[] {};
        Physics.OverlapSphereNonAlloc(player.transform.position, 5f, results);
        return results.ToList().Select(x => x.GetComponent<EnemyBase>()).ToList();
    }
}
