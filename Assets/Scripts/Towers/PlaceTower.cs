using System;
using UnityEngine;

namespace Tower
{
  [RequireComponent(typeof(TowerData))]
  public class PlaceTower : MonoBehaviour
  {
    public static event Action TowerPlaced;
    bool towerPressed;
    static Vector3 correctedMousePos = new();
    TowerData TowerData;
    void Start()
    {
      TowerData = gameObject.GetComponent<TowerData>();
      TowerPlaced += UpdateTowerData;
    }

    void Update()
    {
      if(Input.GetMouseButton(0))
      {
        correctedMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        correctedMousePos.z = 0;
        transform.position = correctedMousePos;
      }
      if(Input.GetMouseButtonUp(0))
      {
        TowerPlaced?.Invoke();
      }
    }

    void UpdateTowerData()
    {
      TowerData.TowerActive = true;
      Destroy(this);
    }
  }
}