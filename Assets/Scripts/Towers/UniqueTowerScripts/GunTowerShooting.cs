using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GunTowerShooting : A_TowerShoot
{
    void Start()
    {
        attackSpeed = 1f;
        range = 3f;
        orderChanged = inRangeOrderCorrection;
        EnemyWaves.EnemyDestroyed += enemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        //if (EnemyWaves.Enemies.Count > 0) { print(EnemyWaves.Enemies[0]); }

        checkRange();
        time += Time.deltaTime;
        if (time > attackSpeed && targetData != null)
        {
            shoot();
            time = 0;
            print("tookdmg");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}
