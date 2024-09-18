using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class ATower : MonoBehaviour
{
    Vector3 cursorPos;
    GameObject dragableObj;
    int layermask = 1 << 8; //not the right layer
    bool pickedUp = false;
    float radius;
    RaycastHit[] hitInfo;
    

    void Start()
    {
        

    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -3));
        towerRange();
    }

    void towerRange()
    {
        radius = 1;
        if (pickedUp == true)
        {
            radius = 0;
        }
        Ray ray = new Ray(transform.position, transform.position);
        hitInfo = Physics.SphereCastAll(ray, radius, 0, layermask);
        for (int i = 0; i < hitInfo.Length; i++)
        {
            //hitInfo[i]
        }

    }
}