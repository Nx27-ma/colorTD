using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class A_TowerShoot : MonoBehaviour
{
    public static Action<GameObject, GameObject> orderChanged;
    protected float range = 0.5f;
    protected float attackSpeed = 0.5f;
    protected float bulletTravelSpeed = 0.5f;
    protected EnemyData targetData;
    protected List<GameObject> inRange = new();
    protected List<GameObject> deleteList = new();
    protected float time = 0;

    #region RangeChecking
    protected void checkRange()
    {
        foreach (GameObject enemy in EnemyWaves.Enemies)
        {


            if (Vector3.Distance(enemy.transform.position, transform.position) < range && !inRange.Contains(enemy))
            {
                inRange.Add(enemy);
                pickTargetData();
            }

        }

        // var targetData = EnemyWaves.Enemies.FirstOrDefault(x => (Vector3.Distance(x.transform.position, transform.position) < range))?.GetComponent<EnemyData>() ?? null;
        //if(inRange2 != null)
        //{
        //    targetData = inRange2.GetComponent<EnemyData>();
        //}

        foreach (GameObject potentialTarget in inRange)
        {
            if (Vector3.Distance(potentialTarget.transform.position, transform.position) > range)
            {
                deleteList.Add(potentialTarget);
            }
        }

        inRange.RemoveAll(x => deleteList.Contains(x));
        deleteList.Clear();

        if (inRange.Count == 0)
        {
            time = 0;
        }
    }

    void pickTargetData()
    {
        targetData = inRange.First().GetComponent<EnemyData>();
    }

    #endregion

    void shoot()
    {
        targetData.TakeDamage(EnemyData.TowerColors.Red);
    }

    #region ActionDelegates
    protected void enemyDied(string smtn, GameObject deadEnemy)
    {
        if (inRange.Contains(deadEnemy))
        {
            inRange.Remove(deadEnemy);
        }
        
    }

    protected void inRangeOrderCorrection(GameObject ascendedObject, GameObject descendedObject)
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
