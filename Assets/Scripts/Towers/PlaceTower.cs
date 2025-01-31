using System;
using UnityEngine;

namespace Tower
{
  [RequireComponent(typeof(TowerData))]
  public class PlaceTower : MonoBehaviour
  {
    public static event Action TowerPlaced;
    static Vector3 correctedMousePos = new();
    TowerData towerData;
    void Start()
    {
      towerData = gameObject.GetComponent<TowerData>();
      TowerPlaced += updateTowerData;
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

    void updateTowerData()
    {
      towerData.TowerActive = true;
      Destroy(this);
    }
  }
}