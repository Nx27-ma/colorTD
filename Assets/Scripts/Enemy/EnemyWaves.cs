using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    int waveNumber = 0;
    int waveWeight;
    GameObject generalEnemy;
    public static Action<string, GameObject> EnemyDestroyed;

    void Start()
    {
        EnemyDestroyed = killEnemy;
        generalEnemy = Resources.Load("Prefabs/Enemies/NormalEnemy") as GameObject;
        print(generalEnemy);
    }

    void Update()
    {
        if (enemies.Count == 0)
        {
            waveNumber++;
            waveWeight = (int)(waveNumber * 1.5f);
            for (int i = 0; i < waveWeight; i++)
            {
                enemies.Add(Instantiate(generalEnemy));
            }
        }
    }

    void killEnemy(string causeOfDeath, GameObject target)
    {
        if(causeOfDeath == "Player")
        {
            //EconomyAction
        } 
        else if (causeOfDeath == "EndOfTrack")
        {
            //UIPlayerLoseHP
            target = enemies[enemies.Count - 1];
        }

        enemies.RemoveAt(enemies.FindIndex(e => e == target));

        Destroy(target);
    }



}
