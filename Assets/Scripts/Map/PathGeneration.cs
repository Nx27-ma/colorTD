using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utils;

public class PathGeneration : MonoBehaviour
{
    GameObject[] pathPoints;
    void Start()
    {
        GameObject path = null;
        while (path == null)
        {
            path = GameObject.Find("PathPoints");
        }

       pathPoints = FindChildren.GetDirectChildren(path);
        

    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
}
