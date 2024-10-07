using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public static List<GameObject> Enemies = new List<GameObject>();
    public static Action<string, GameObject> EnemyDestroyed;
    public static Action StartWave;


    int waveNumber = 0;
    int waveWeight;
    GameObject generalEnemy;


    void Start()
    {
        StartWave = generateWave;
        EnemyDestroyed = killEnemy;
        generalEnemy = Resources.Load("Prefabs/Enemies/NormalEnemy") as GameObject;
        print(generalEnemy);
    }

    void generateWave()
    {
        if (Enemies.Count == 0)
        {
            waveNumber++;
            waveWeight = (int)(waveNumber * 1.5f);

            for (int i = 0; i < waveWeight; i++)
            {
                Enemies.Add(Instantiate(generalEnemy));
            }
        }
    }
    

    void killEnemy(string causeOfDeath, GameObject target)
    {
        print("Whoops delegate called!");
        if(causeOfDeath == "Player")
        {
            //EconomyAction
        } 
        else if (causeOfDeath == "EndOfTrack")
        {
            //UIPlayerLoseHP
        }

        Enemies.RemoveAt(Enemies.FindIndex(e => e == target));

        Destroy(target);
    }



}
