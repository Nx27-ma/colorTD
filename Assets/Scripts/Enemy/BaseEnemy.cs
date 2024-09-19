using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class BaseEnemy : MonoBehaviour
{
    Spline path;
    void Start()
    {
        path = GameObject.FindWithTag("DEFAULT").GetComponent(MapGen).spline as Spline;
    }

    // Update is called once per frame
    void Update()
    {
        SplineUtility.
    }
}
