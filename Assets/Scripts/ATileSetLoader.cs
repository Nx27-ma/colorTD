using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class ATileSetLoader<T> where T : ATileSetLoader<T>
{
  public Tilemap[] TileMaps;
  private string pathForTileSet;

  protected ATileSetLoader() => pathForTileSet = $"TileSets/{typeof(T).Name}";
  protected void GetTileMaps()
  {
    TileMaps = Resources.LoadAll<Tilemap>(pathForTileSet);
  }

  public Tilemap GetTileSetByName(string name)
  {
    foreach (Tilemap tileMap in TileMaps)
    {
      if (tileMap.name == name) return tileMap;
    }
    Debug.LogError($"Found nothing with {name}, {this} is where it was called");
    return null;
  }
}
