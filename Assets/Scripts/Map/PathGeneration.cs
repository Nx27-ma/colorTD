using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utils;

public class PathGeneration : MonoBehaviour
{
    GameObject[] pathPoints;
    float width = 0.5f;
    void Start()
    {
        GameObject path = GameObject.Find("PathPoints");

        pathPoints = FindChildren.GetDirectChildren(path);




        pathPoints[0].transform.LookAt(pathPoints[1].transform.position);

        Vector3 angles = pathPoints[0].transform.eulerAngles;

        Vector3 firstAngle = new Vector3(angles.x, angles.y + 90, 0);
        pathPoints[0].transform.eulerAngles = firstAngle;
        pathPoints[0].transform.Translate(new Vector3(0, width), Space.Self);
        GameObject spheretest = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 temppos = new Vector3 (pathPoints[0].transform.position.x , pathPoints[0].transform.position.y);
        spheretest.transform.position = temppos;

        transform.Translate(new Vector3(0, -width * 2), Space.Self);
        GameObject spheretest1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        spheretest1.transform.position = pathPoints[0].transform.position;
    }



    // Update is called once per frame
    void Update()
    {

    }
}
