using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  private Transform[] WayPoints;

  void Start()
  {
    Transform[] tempWp = GameObject.FindGameObjectWithTag("WayPoints").GetComponentsInChildren<Transform>();
  }

  void FixedUpdate()
  {
    
  }
}
