using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyTrackData : MonoBehaviour
{
    private Transform EndPoint;

    public static event Action<GameObject> EndReached;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position == EndPoint.position)
        {
            EndReached?.Invoke(gameObject);
        }
    }


}
