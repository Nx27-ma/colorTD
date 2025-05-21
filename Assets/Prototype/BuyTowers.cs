using System;
using UnityEngine;
using static AssetLoader;

public class BuyTowers : MonoBehaviour 
{
  GameObject towerParent;
  void Start()
  {
    towerParent = GameObject.Find("Towers");
    if (towerParent == null)
    {
      Debug.LogError("Towers parent not found");
      return;
    }
  }
  public void ButtonPressed(string towerTypes)
  {
    GameObject prefab;
    try
    {
      prefab = TowerPrefabs[(TowerTypes)Enum.Parse(typeof(TowerTypes), towerTypes)];
      Instantiate(prefab, new Vector2(100,100), Quaternion.identity, towerParent.transform);
    }
    catch (Exception e)
    {
      Debug.LogError($"{e}");
      return;
    }
  }
}
