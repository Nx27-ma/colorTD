using UnityEngine;

namespace Tower
{
  public class TowerData : MonoBehaviour
  {
    [SerializeField] internal TowerColor TowerColor = TowerColor.Red;
    [SerializeField] internal TowerType TowerType = TowerType.Default;
    [SerializeField] internal bool TowerActive = false;
  }
}