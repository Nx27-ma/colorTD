using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerShooting : A_TowerShoot
{
    void Start()
    {
        range = 1f;
        orderChanged = inRangeOrderCorrection;
        EnemyWaves.EnemyDestroyed += enemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        //if (EnemyWaves.Enemies.Count > 0) { print(EnemyWaves.Enemies[0]); }
        
        checkRange();
        time += Time.deltaTime;
        if (time > attackSpeed)
        {
            targetData.TakeDamage(EnemyData.TowerColors.Blue);
            time = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, range);
    }
}
