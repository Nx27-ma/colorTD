using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PlayerUserInterface : MonoBehaviour
{
    [SerializeField] GameObject lost, won, towerPanel;
    TMP_Text wave, lives;
    PlayerData playerData;
    EnemyWaves enemyWaves;
    void Start()
    {
        enemyWaves = GameObject.Find("DEFAULT").GetComponent<EnemyWaves>();
        playerData = GameObject.Find("DEFAULT").GetComponent<PlayerData>();
        GameObject wavesTemp = GameObject.Find("Waves");
        GameObject livesTemp = GameObject.Find("Lives");
        wave = wavesTemp.gameObject.GetComponent<TMP_Text>();
        lives = livesTemp.gameObject.GetComponent<TMP_Text>();
        towerPanel = GameObject.Find("PanelPlacement");
        //lost =  GameObject.Find("PanelLost");
        //won = GameObject.Find("PanelWon");
    }

    // Update is called once per frame
    void Update()
    {
        wave.text = $"Waves: {enemyWaves.WaveNumber} / {enemyWaves.MaxWave}";
        lives.text = $"Lives: {playerData.Lives}";
    }

    public void DefeatScreen()
    {
        towerPanel.SetActive(false);
        lost.SetActive(true); 
    }

    public void VictoryScreen()
    {
        towerPanel.SetActive(false);
        won.SetActive(true);
    }
}
