using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Lives { get; private set; } = 5;
    PlayerUserInterface playerUserInterface;
    EnemyWaves enemyWaves;
    private TowerPlace towerPlace;
    [SerializeField] GameObject panelPlacement;
    public void DeminishLives()
    {
        Lives--;
    }
    void Start()
    {
        GameObject defaultObj = GameObject.Find("DEFAULT");
        playerUserInterface = panelPlacement.GetComponent<PlayerUserInterface>();
        enemyWaves = defaultObj.GetComponent<EnemyWaves>();
        towerPlace = defaultObj.GetComponent<TowerPlace>();
    }

    void Update()
    {

        if (Lives <= 0)
        {
            playerUserInterface.DefeatScreen();
            Lives = 5;
            enemyWaves.WaveNumber = 0;
            towerPlace.removeAllTowers();
        }
        

    }

    public void WonGame()
    {
        if (enemyWaves.WaveNumber == enemyWaves.MaxWave)
        {
            playerUserInterface.VictoryScreen();
            Lives = 5;
            enemyWaves.WaveNumber = 0;
            towerPlace.removeAllTowers();
        }

    }
}
