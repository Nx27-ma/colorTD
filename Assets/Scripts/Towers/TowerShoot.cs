using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public static Action<GameObject, GameObject> orderChanged;
    float range = 0.5f;
    float attackSpeed;
    float bulletTravelSpeed = 0.5f; //tempvariable
    EnemyData targetData;
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
            if (Vector3.Distance(EnemyWaves.Enemies[i].transform.position, transform.position) < range && !inRange.Contains(EnemyWaves.Enemies[i]))
            {
                inRange.Add(EnemyWaves.Enemies[i]);
                pickTargetData();
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


    void pickTargetData()
    {
        targetData = inRange[0].GetComponent<EnemyData>();
    }
    /// <summary>
    /// Ty = Ta * Tx && Ey = Ea * Ex //denkstap
    /// Ta * Tx = Ea * Ex && Ty = Ey //denkstap
    /// Tx = 1 && Ex = 1 
    ///     ///// Ty = EnemySpeed * Tx
    /// 
    /// </summary>
    void calculateShootingLocation()
    { 
        float Tx, Ty, Ta, Ex, Ey, Ea;

        Tx = Ey = targetData.Speed;
        float tempVar = Tx * bulletTravelSpeed; //Ey = Ta * Tx + Ex 
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
                pickTargetData();
            }
        }

    }

    #endregion
}
