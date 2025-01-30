using System;
using UnityEngine;

public class EnemyTrackData : MonoBehaviour
{
  public static event Action<GameObject> EndReached;
  private Transform EndPoint;
  void Start()
  {
    Transform[] tempWp = GameObject.FindGameObjectWithTag("WayPoints").GetComponentsInChildren<Transform>();
    EndPoint = tempWp[tempWp.Length - 1];
  }

  void Update()
  {
    if (transform.position == EndPoint.position)
    {
      EndReached?.Invoke(gameObject);
    }
  }
}
