using System;
using UnityEngine;

public class CursorTD : MonoBehaviour
{
  public static event Action<GameObject> IsCursorInCollider;
  public static event Action<GameObject> IsBeingClickedOn;
  public Vector2 CursorPos;
  

  RaycastHit2D hit;
  void FixedUpdate()
  {
    CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    hit = Physics2D.Raycast(CursorPos, Vector3.forward, Mathf.Infinity);
    if (hit.collider)
    {
      print(hit.collider.gameObject.name);
      IsCursorInCollider?.Invoke(hit.collider.gameObject);
      if (Input.GetMouseButtonDown(0))
      {
        IsBeingClickedOn?.Invoke(hit.collider.gameObject);
      }
    }
  }
}
