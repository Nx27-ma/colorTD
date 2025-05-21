using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GridCellBase : MonoBehaviour
{
  public BoxCollider2D BoxCollider { get => boxCollider; set => boxCollider = value; }
  BoxCollider2D boxCollider;
  public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
  SpriteRenderer spriteRenderer;
  public bool IsOccupied;



  void Start()
  {
    boxCollider = GetComponentInChildren<BoxCollider2D>();
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }
}
