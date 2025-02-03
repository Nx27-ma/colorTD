using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace Map
{
  internal class MapTiles : ATileSetLoader<MapTiles>
  {
    public static MapTiles Instance = new MapTiles();
    private MapTiles()
    {
      GetTileMaps();
      GetTileSetByName("name");
    }
  }

}