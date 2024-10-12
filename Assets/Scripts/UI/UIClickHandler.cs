using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;
public class UIClickHandler : MonoBehaviour
{
    //Set all panels on inactive except main

    GameObject canvas;
    GameObject[] panels;
    Button[] buttons;
    public GameObject SelectedGameObject;
    public TowerPlace towerPlace;
    void Start()
    {
        towerPlace = gameObject.GetComponent<TowerPlace>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        panels = FindChildren.GetDirectChildren(canvas);
        Type buttonType = typeof(Button);
        buttons = FindChildren.GetAllChildrenOfType<Button>(panels[(int)PanelType.main]);
    }

    public void MainScreenPanelButtons(string name)
    {
        if (name == "Start")
        {
            panels[(int)PanelType.tower].SetActive(true);
            panels[(int)PanelType.main].SetActive(false);
        }
        else
        {
            Application.Quit();
            Debug.Log("Else statement reached - Should be intended");
        }

    }
    public void TowerPlacementButtons(GameObject game0bject)
    {
        towerPlace.ButtonClickedAction(Instantiate(game0bject));
    }

    public void NextWave()
    {
        EnemyWaves.StartWave();
    }

    public void LossState()
    {
        panels[(int)PanelType.main].SetActive(true);
        panels[(int)PanelType.lost].SetActive(false);
    }

    public void VictoryState()
    {
        panels[(int)PanelType.main].SetActive(true);
        panels[(int)PanelType.won].SetActive(false);
    }

    enum PanelType
    {
        main, tower, lost, won
    }
}
