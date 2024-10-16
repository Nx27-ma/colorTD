using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PlayerUserInterface : MonoBehaviour
{
    GameObject lost, won, towerPanel;
    TMP_Text money ,lives;
    void Start()
    {
        GameObject moneyTemp = GameObject.Find("Money");
        GameObject livesTemp = GameObject.Find("Lives");
        money = moneyTemp.gameObject.GetComponent<TMP_Text>();
        lives = livesTemp.gameObject.GetComponent<TMP_Text>();
        towerPanel = GameObject.Find("PanelPlacement");
        lost =  GameObject.Find("PanelLost");
        won = GameObject.Find("PanelWon");
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Lives: 5";
        lives.text = "Lives: 5";
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
