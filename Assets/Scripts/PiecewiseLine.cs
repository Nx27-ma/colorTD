using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PiecewiseLine : MonoBehaviour
{
  void Start()
  {

  }
  void Update()
  {

  }
}

public class Line
{
  private Vector2 endPoint, startPoint;
  private Vector2 dVector;
  private Vector2 newPosition;
  public Line(Vector2 startPoint, Vector2 endPoint)
  {
    this.startPoint = startPoint;
    this.endPoint = endPoint;
    dVector = new(startPoint.x - endPoint.x, startPoint.y - endPoint.y);
    dVector = dVector.normalized;
    newPosition = dVector * 6;
  }

  public void LineStep(float step)
  {

  }
}