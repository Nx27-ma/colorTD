using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    Vector3 cursorPos;
    GameObject dragableObj;

    void Start()
    {
        dragableObj = GameObject.CreatePrimitive(PrimitiveType.Cube);       

    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3));
        
    }  
}