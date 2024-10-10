using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utils;



public class MoveEnemy : MonoBehaviour
{
    private GameObject path;
    private GameObject[] pathChildren;
    private float speed;
    public float totalDistanceMovedOverLine { get; private set; }

    void Start()
    {
        while (path == null)
        {
            path = GameObject.Find("PathPoints");
        }

        pathChildren = FindChildren.GetDirectChildren(path);

        speed = GetComponent<EnemyData>().Speed;

        if (speed == 0) Debug.LogError("Couldn't get speed from EnemyData"); 
    }

    void totalAmountMoved(Vector3 oldPos, Vector3 newPos)
    {
        totalDistanceMovedOverLine += Vector3.Distance(oldPos, newPos);
    }

    int i = 0;
    Vector3 currentPos;
    Vector3 newPostion;
    private void FixedUpdate()
    {
        currentPos = transform.position;
        newPostion = transform.position = Vector3.MoveTowards(transform.position, pathChildren[i].transform.position, speed);
        totalAmountMoved(currentPos, newPostion);

        if (transform.position == pathChildren[i].transform.position)
        {
            i++;
        }

        else if (i == pathChildren.Length - 1)
        {
            EnemyWaves.EnemyDestroyed("EndOfTrack", gameObject);
        }
    }
}
