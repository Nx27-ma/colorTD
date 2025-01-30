using System;
using Tower;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PurchaseUI : MonoBehaviour
{
  GameObject towerPrefab;
  Button button;
  GameObject buttonPressed;
  void Start()
  {
    towerPrefab = Resources.Load<GameObject>("Prefabs/Tower/TowerBase");
    PlaceTower.TowerPlaced += enableButton;
  }
  public void PurchaseRequest(string nameOfTower)
  {
    if (!Enum.IsDefined(typeof(TowerType), nameOfTower))
    {
      Debug.LogError($"{nameOfTower} does not exist - instantiating default");
    }
    buttonPressed = EventSystem.current.currentSelectedGameObject;
    Instantiate(towerPrefab);
    buttonPressed.GetComponent<Button>().interactable = false;
  }

  void enableButton()
  {
    buttonPressed.GetComponent<Button>().interactable = true;
  }
}
