using System;
using System.Collections.Generic;
using UnityEngine;

public static class AssetLoader
{
  public static Dictionary<TowerTypes, GameObject> TowerPrefabs;
  static GameObject[] towers;
  static AssetLoader()
  {
    TowerPrefabs = new();
    try
    {
      towers = Resources.LoadAll<GameObject>("Towers/");
    }
    catch (Exception e)
    {
      Debug.LogError($"{e }");
      return;
    }

    foreach (GameObject tower in towers)
    {
      TowerPrefabs.Add((TowerTypes)Enum.Parse(typeof(TowerTypes), tower.name), tower);
    }
  }
}
