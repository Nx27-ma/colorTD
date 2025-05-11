using UnityEngine;

public class GridTD : MonoBehaviour
{
  public int XCells;
  public int YCells;
  public float SizeBetweenCells;
  public GridCell[,] cells;

  public int x, y;
  void Start()
  {
    cells = new GridCell[XCells, YCells];
    for (int x = 0; x < XCells; x++)
    {
      for (int y = 0; y < YCells; y++)
      {
        GridCell cell = new();
        cell.Cell.transform.position = new Vector3(x * SizeBetweenCells + transform.position.x, y * SizeBetweenCells + transform.position.y, 0);

        cells[x,y] = cell;
        this.x = x;
        this.y = y;
      }
    }
  }
#if UNITY_EDITOR
  private void FixedUpdate()
  {
    for (int x = 0; x < XCells; x++)
    {
      for (int y = 0; y < YCells; y++)
      {
        cells[x, y].Cell.transform.position = new Vector3(x * SizeBetweenCells + transform.position.x, y * SizeBetweenCells + transform.position.y, 0);
      }
    }
  }
#endif
}
