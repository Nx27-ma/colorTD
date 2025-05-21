using UnityEngine;
using static AssetLoader;

public class GridTD : MonoBehaviour
{
  public int XCells;
  public int YCells;
  public float SizeBetweenCells;
  public GameObject[,] cells;

  int x, y;
  void Start()
  {
    GameObject grid = GameObject.Find("Grid");
    cells = new GameObject[XCells, YCells];
    for (int x = 0; x < XCells; x++)
    {
      for (int y = 0; y < YCells; y++)
      {
        GameObject cell = Instantiate(GridTilePrefabs[0], grid.transform);
        cell.transform.position = new Vector3(x * SizeBetweenCells + transform.position.x, y * SizeBetweenCells + transform.position.y, 0);

        cells[x, y] = cell;
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
        cells[x, y].transform.position = new Vector3(x * SizeBetweenCells + transform.position.x, y * SizeBetweenCells + transform.position.y, 0);
      }
    }
  }
#endif
}
