using System;
using UnityEngine;

[RequireComponent(typeof(GridTD))]

public class GridSnapping : MonoBehaviour
{
  public static event Action<GameObject> HoveringOverGrid;
  GridTD grid;
  void Start()
  {
    grid = GetComponent<GridTD>();
    CursorTD.IsCursorInCollider += HighLight;
  }
  
  void HighLight(GameObject gameObject)
  {
    for (int x = 0; x < grid.cells.GetLength(0); x++)
    {
      for (int y = 0; y < grid.cells.GetLength(1) ; y++)
      {
        if (gameObject == grid.cells[x,y].Cell)
        {
          grid.cells[x, y].SpriteRenderer.color = Color.red;
          HoveringOverGrid?.Invoke(grid.cells[x, y].Cell);
        }
        else
        {
          grid.cells[x, y].SpriteRenderer.color = Color.white;
        }
      }
    }
  }

}
