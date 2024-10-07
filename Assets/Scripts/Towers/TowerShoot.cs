using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    float range = 0.5f;
    List<GameObject> inRange = new List<GameObject>();

    void Start()
    {
        EnemyWaves.EnemyDestroyed += EnemyDied;
    }

    void Update()
    {
        checkRange();
    }

    void checkRange()
    {
        for (int i = 0; i < EnemyWaves.Enemies.Count; i++)
        {
            if (Vector3.Distance(EnemyWaves.Enemies[i].transform.position, transform.position) < range)
            {
                inRange.Add(EnemyWaves.Enemies[i]);
            } 
        }

        for (int i = 0; i < inRange.Count; i++)
        {
            if (Vector3.Distance(inRange[i].transform.position, transform.position) > range)
            {
                inRange[i] = null;  
            }
        }
        while (inRange.Contains(null))
        {
            inRange.RemoveAt(inRange.FindIndex(i => i == null));
        }   
    }

    public void EnemyDied(string smtn, GameObject deadEnemy)
    {
        inRange.RemoveAt(inRange.FindIndex(i => i == deadEnemy));
    }
}
