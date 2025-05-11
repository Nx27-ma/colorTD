using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
  public GameObject Cell;
  public BoxCollider2D BoxCollider;
  public SpriteRenderer SpriteRenderer;
  [SerializeField] bool isOccupied;
  [SerializeField] Sprite sprite;

  public GridCell(bool startActive = true)
  {
    isOccupied = startActive;
    Cell = new GameObject("Cell");
    BoxCollider = Cell.AddComponent<BoxCollider2D>();
    SpriteRenderer = Cell.AddComponent<SpriteRenderer>();
    sprite = Resources.Load<Sprite>("GridTiles/WhiteGridTileBasic");
    SpriteRenderer.sprite = sprite;
    SpriteRenderer.drawMode = SpriteDrawMode.Sliced;
    SpriteRenderer.size = new Vector2(1, 1);
  }
}
