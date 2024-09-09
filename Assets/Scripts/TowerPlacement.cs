using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    Vector3 cursorPos;
    GameObject dragableObj;
    GameObject canvas;
    GameObject[] buttonS;

    void Start()
    {
        dragableObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        canvas = GameObject.Find("Canvas");
        
        Transform frame = canvas.transform.Find("Frame");

        buttonS = new GameObject[frame.childCount];

        for (int i = 0; i < frame.childCount; i++)
        {
            buttonS[i] = frame.GetChild(i).gameObject;
        }
        

    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3));
        
    }
}
