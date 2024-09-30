using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class TowerPlace : MonoBehaviour
{
    private Vector3 cursorPos;
    GameObject pathPointObj;
    GameObject[] pathPoints;

    void Start()
    {
        pathPointObj = GameObject.Find("PathPoints");
        pathPoints = Utils.getDirectChildren(pathPointObj);

    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3));
        
    }

    bool checkValidPlacement()
    {
        bool path = false;
        bool otherTower;
        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (Vector3.Distance(cursorPos, pathPoints[i].transform.position) > 0.5f)
            {
                path = true;
            }
        }
      
            




        return true;
    }


}