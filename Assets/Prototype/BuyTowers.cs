using System;
using UnityEngine;
using static AssetLoader;

public class BuyTowers : MonoBehaviour 
{
  public void ButtonPressed(string towerTypes)
  {
    GameObject prefab;
    try
    {
      prefab = TowerPrefabs[(TowerTypes)Enum.Parse(typeof(TowerTypes), towerTypes)];
      Instantiate(prefab);
    }
    catch (Exception e)
    {
      Debug.LogError($"Error: {e}");
      return;
    }
  }
}
