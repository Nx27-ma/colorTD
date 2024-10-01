using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;
public class TowerPlace : MonoBehaviour
{
    GameObject Default;
    UIClickHandler uiClickHandler;
    GameObject pathPointObj;
    GameObject[] pathPoints;

    static List<GameObject> towers;
    static Vector3 cursorPos;

    public Action<GameObject> ButtonClickedAction;

    bool path = false, otherTower = false, reinstantiate = true;
  

    void Start()
    {
        towers = new List<GameObject>();
        Default = GameObject.Find("DEFAULT");
        uiClickHandler = Default.GetComponent<UIClickHandler>();        //for interaction with the ui
        pathPointObj = GameObject.Find("PathPoints");
        pathPoints = Utils.getDirectChildren(pathPointObj);

        ButtonClickedAction = inputTowerPlacement;
    }

    private void  inputTowerPlacement(GameObject obj)
    {
        int index = towers.Count;
        towers.Add(obj);

        StartCoroutine(moveTower(index));
    }

    IEnumerator moveTower(int index)
    {
        towers[index].transform.position = cursorPos;
        yield return null;

        if (Input.GetMouseButtonDown(0))
        {
            
        }
        else
        {
            StartCoroutine(moveTower(index));
        }
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }
    
    bool checkValidPlacement()
    {
        path = false;
        otherTower = false;

        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (Vector3.Distance(cursorPos, pathPoints[i].transform.position) > 0.5f)
            {
                path = true;
            }
        }






        return true;
    }





    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            for (int i = 0; i < pathPoints.Length; i++)
            {
                Gizmos.DrawSphere(pathPoints[i].transform.position, 0.5f);
            }
        }
    }

}
