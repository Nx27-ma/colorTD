using UnityEngine;
using System.Collections;


public class TowerInit : MonoBehaviour
{
  void Start()
  {
    gameObject.GetComponentInChildren<SpriteRenderer>().forceRenderingOff = false;
  }
}
