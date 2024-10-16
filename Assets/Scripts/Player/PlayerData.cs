using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Lives { get; private set; } = 5;
    PlayerUserInterface player;
    EnemyWaves enemyWaves;
    public void DeminishLives()
    {
        Lives--;
    }
    void Start()
    {
        GameObject defaultObj = GameObject.Find("DEFAULT");
        player = defaultObj.GetComponent<PlayerUserInterface>();
       enemyWaves = defaultObj.GetComponent<EnemyWaves>();
    }

    void Update()
    {
        if (Lives <= 0)
        {
            player.DefeatScreen();
        }
        if (enemyWaves.WaveNumber > 10)
        {
            player.VictoryScreen();
        }
    }
}
