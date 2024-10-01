using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    List<GameObject> waves = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();
    int waveNumber = 0;
    int waveWeight;
    GameObject[] enemyTypes;

    void Start()
    {
        GameObject normal = Resources.Load("Prefabs/Enemies/Normal enemy") as GameObject;
    }

    void Update()
    {
        if (waves.Count == 0)
        {
            waveNumber++;
            waveWeight = (int)(waveNumber * 1.5f);
            for (int i = 0; i < waveWeight; i++)
            {
                //enemies.Add();
            }

        }
    }
}
