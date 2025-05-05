using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell
{
  public GameObject Cell;
  public BoxCollider2D BoxCollider;
  public SpriteRenderer SpriteRenderer;
  bool IsOccupied;
  Sprite Sprite;

  public GridCell(bool startActive = true)
  {
    Cell = new GameObject("Cell");
    BoxCollider = Cell.AddComponent<BoxCollider2D>();
    SpriteRenderer = Cell.AddComponent<SpriteRenderer>();
    IsOccupied = startActive;
    Sprite = Resources.Load<Sprite>("GridTiles/Cell");

  }
}
