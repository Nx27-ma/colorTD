using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveEnemy : MonoBehaviour
{
    private GameObject path;
    private GameObject[] pathChildren;
    private float speed = 0.1f;

    void Start()
    {
        while (path == null)
        {
            path = GameObject.Find("PathPoints");
        }

        pathChildren = Utils.getDirectChildren(path);

        int i = 0;
            StartCoroutine(moveBetweenPoints(i));
    }

    IEnumerator moveBetweenPoints(int i)
    {
        transform.position = Vector3.MoveTowards(transform.position, pathChildren[i].transform.position, speed);
        Debug.Log("posUpdated");
        yield return new WaitForFixedUpdate();
        if (transform.position != pathChildren[i].transform.position)
        {
            StartCoroutine(moveBetweenPoints(i));
        }
        else if (i > pathChildren.Length)
        {
            Debug.Log("Done");
            
        }
        else
        {
            i++;
            StartCoroutine(moveBetweenPoints(i));
        }


    }


}
