using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public static Action<GameObject, GameObject> orderChanged;
    float range = 0.5f;
    List<GameObject> inRange = new List<GameObject>();

    void Start()
    {
        orderChanged = inRangeOrderCorrection;
        EnemyWaves.EnemyDestroyed += EnemyDied;
    }

    void Update()
    {
        checkRange();
    }

    #region RangeChecking
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
    #endregion
    


    GameObject pickTarget()
    {
        return inRange[0]; 
    }




    #region ActionDelegates
    public void EnemyDied(string smtn, GameObject deadEnemy)
    {
        inRange.RemoveAt(inRange.FindIndex(i => i == deadEnemy));
    }

    void inRangeOrderCorrection(GameObject ascendedObject, GameObject descendedObject)
    {
        for (int i = 0; inRange.Count > i; i++)
        {
            if (ascendedObject == inRange[i] && descendedObject == inRange[i + 1])
            {
                inRange[i] = descendedObject;
                inRange[i + 1] = ascendedObject;
                
            }
        }
    }

    #endregion
}
