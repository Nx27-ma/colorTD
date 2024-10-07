using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    float range = 0.5f;
    Queue<GameObject> inRange = new Queue<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        checkRange();
    }

    void checkRange()
    {
        for (int i = 0; i < range; i++)
        {
            if (Vector3.Distance(EnemyWaves.enemies[i].transform.position, transform.position) < range)
            {
                inRange.Enqueue(EnemyWaves.enemies[i]);
            }
        }
    }

    public void EnemyDied(GameObject deadEnemy)
    {
        if (inRange.Peek() == deadEnemy)
        {
            inRange.Dequeue();
        }

    }
}
