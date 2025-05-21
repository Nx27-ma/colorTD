using UnityEngine;

//Must be applied on the object that you're trying to place on the grid
public class PlaceOnGrid : MonoBehaviour
{
  CursorTD cursor;
  void Start()
  {
    cursor = GameObject.Find("ScriptInitializer").GetComponent<CursorTD>();
    GridSnapping.HoveringOverGrid += placeTower;
  }
  void FixedUpdate()
  {
    transform.position = cursor.CursorPos;
  }
  void placeTower(GameObject incomingObj)
  {
    gameObject.transform.position = incomingObj.transform.position;
  }
  
}
