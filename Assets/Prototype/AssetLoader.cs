using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AssetLoader
{
  public static Dictionary<TowerTypes, GameObject> TowerPrefabs;
  public static Dictionary<GridTileTypes, GameObject> GridTilePrefabs;
  static AssetLoader()
  {
    TowerPrefabs = new();
    try
    {
      TowerPrefabs = Resources.LoadAll<GameObject>("Prefabs/Towers/")
        .ToDictionary(tower => (TowerTypes)Enum.Parse(typeof(TowerTypes), tower.name), tower => tower);

      GridTilePrefabs = Resources.LoadAll<GameObject>("Prefabs/Grid/")
        .ToDictionary(tile => (GridTileTypes)Enum.Parse(typeof(GridTileTypes), tile.name), tile => tile);
    }
    catch (Exception e)
    {
      Debug.LogError($"{e}");
      return;
    }
  }
}
