using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utils;

public class PathGeneration : MonoBehaviour
{
    GameObject[] pathPoints;
    float totalPathLenght;
    void Start()
    {
        GameObject path = null;
        while (path == null)
        {
            path = GameObject.Find("PathPoints");
        }

       pathPoints = FindChildren.GetDirectChildren(path);


        for (int i = 0; i < pathPoints.Length-1; i++)
        {
            totalPathLenght += Vector3.Distance(pathPoints[i].transform.position, pathPoints[i +1].transform.position);
        }


    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
}
