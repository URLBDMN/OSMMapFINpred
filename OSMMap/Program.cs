using OSMMapLib;
using System;

namespace OSMMap
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Tile tile = new Tile(1, 2, 3, "AAA");
            Console.WriteLine(tile.ToString());*/
            Layer layer1 = new Layer();
            Map map = new Map();
            map.Layer = layer1;
            map.Lat = 49.84335531583281;
            map.Lon = 18.173273993447488;
            map.Zoom = 17;

            map.Render();
          // Console.WriteLine(layer1.FormatUrl(5,2,7));
          
        }
    }
}
