using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyBase> Enemies;
    private List<EnemyBase> aliveEnemies;

    private void Awake()
    {
            var loadedEnemies = ES3.KeyExists("Enemies") ? ES3.Load<List<bool>>("Enemies") : null;

            if (loadedEnemies == null) return;
            
            for (var i = 0; i < Enemies.Count; i++)
                Enemies[i].gameObject.SetActive(loadedEnemies[i]);
    }

    private void OnEnable()
    {
        GameActions.SaveGame += SaveGame;
    }
    
    private void OnDisable()
    {
        GameActions.SaveGame -= SaveGame;
    }

    private void SaveGame()
    {
       ES3.Save("Enemies", Enemies.Select(x=>x.gameObject.activeSelf).ToList());
    }
    
}


public static class GameActions
{
    public static Action OnGameFailed;
    public static Action OnGameWin;
    public static Action SaveGame;
}
