using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridContainer
{
  ICellContent[,] Grid;
  int x, y;
  public GridContainer(int x, int y)
  {
    this.x = x;
    this.y = y;
    Grid = generateMapArrays<ICellContent>(x, y);
    ICellContent.GetAllOfType<ICellContent>();
  }

  T[,] generateMapArrays<T>(int x, int y) 
  {
    T[,] ints = new T[x,y];
    return ints;
  }
}
