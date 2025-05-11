using System;
using UnityEngine;
using static AssetLoader;

public class BuyTowers : MonoBehaviour 
{
  public void ButtonPressed(string towerTypes)
  {
    GameObject prefab;
    print("FIck dich");
    prefab = TowerPrefabs[(TowerTypes)Enum.Parse(typeof(TowerTypes), towerTypes)];
    Instantiate(prefab); 
  }
}
