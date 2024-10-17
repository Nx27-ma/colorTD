using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
using Utils;
public class TowerPlace : MonoBehaviour
{
    static List<GameObject> towers;
    static Vector3 cursorPos;

    public Action<GameObject> ButtonClickedAction;

    bool path = false, otherTower = false;
    private int index;
    private bool clickedState;

    void Start()
    {
        towers = new List<GameObject>();
           //for interaction with the ui
        ButtonClickedAction = inputTowerPlacement;
    }

    private void  inputTowerPlacement(GameObject obj)
    {
        towers.Add(obj);
        clickedState = true;
    }

    public void removeAllTowers()
    {
        foreach (GameObject obj in towers)
        {
            Destroy(obj);
        }
        towers.Clear();
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

        if (clickedState)
        {
            towers[towers.Count - 1].transform.position = cursorPos;

            if (Input.GetMouseButtonDown(0))
            {
                clickedState = false;
            }
        }
    }
    
    bool checkValidPlacement()
    {
        path = false;
        otherTower = false;







        return true;
    }
}

