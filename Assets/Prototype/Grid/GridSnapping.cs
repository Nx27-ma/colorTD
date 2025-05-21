using System;
using UnityEngine;

[RequireComponent(typeof(GridTD))]
[DefaultExecutionOrder(100)]
public class GridSnapping : MonoBehaviour
{
  public static event Action<GameObject> HoveringOverGrid;
  GridTD grid;
  GridCellBase[,] GridCellBases;
  void Start()
  {
    grid = GetComponent<GridTD>();
    GridCellBases = new GridCellBase[grid.cells.GetLength(0), grid.cells.GetLength(1)];
 
      CursorTD cursor = GameObject.Find("ScriptInitializer").GetComponent<CursorTD>();
   
    cursor.IsCursorInCollider += HighLight;
    for (int x = 0; x < grid.cells.GetLength(0); x++)
    {
      for (int y = 0; y < grid.cells.GetLength(1); y++)
      {
        GridCellBases[x, y] = grid.cells[x, y].GetComponentInChildren<GridCellBase>();
      }
    }
    print(GridCellBases[0,0]);
  }
  
  void HighLight(GameObject gameObj)
  {
    for (int x = 0; x < grid.cells.GetLength(0); x++)
    {
      for (int y = 0; y < grid.cells.GetLength(1) ; y++)
      {
        if (gameObj == grid.cells[x,y])
        {
          GridCellBases[x, y].SpriteRenderer.color = Color.red;
          
          HoveringOverGrid?.Invoke(grid.cells[x, y].gameObject);
        }
        else
        {
          GridCellBases[x, y].SpriteRenderer.color = Color.white;
        }
      }
    }
  }

}
