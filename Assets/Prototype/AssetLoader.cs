using System;
using System.Collections.Generic;
using UnityEngine;

public static class AssetLoader
{
  public static Dictionary<TowerTypes, GameObject> TowerPrefabs;
  static AssetLoader()
  {
    GameObject[] towers = Resources.LoadAll<GameObject>("Towers");
    Debug.Log(towers);
    foreach (GameObject tower in towers)
    {
      TowerPrefabs.Add((TowerTypes)Enum.Parse(typeof(TowerTypes), tower.name), tower);
    }
    Debug.Log(TowerPrefabs);
  }
}
