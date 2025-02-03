namespace Map
{
  public class GridContainer
  {
    ICellContent[,] Grid;
    int x, y;
    public GridContainer(int x, int y)
    {
      this.x = x;
      this.y = y;
      Grid = generateMapArrays<ICellContent>(x, y);
    }

    T[,] generateMapArrays<T>(int x, int y)
    {
      T[,] ints = new T[x, y];
      return ints;
    }
  }
}