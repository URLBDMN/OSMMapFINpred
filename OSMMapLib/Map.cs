using MapRendererLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMMapLib
{
    public class Map
    {



        public Layer Layer { get; set; }


        private double lat;
        public double Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = (value+ 90.0) % 180 - 90;
            }
        }

        private double lon;
        public double Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = (value + 180.0) % 360 - 180;
            }
        }
        public int Zoom
        {
            get
            {
                var rand = new Random();
                return Layer.MaxZoom;

            }
            set
            {
                

            }
        }

        private int CenterTileX
        {
            get { return (int)((Lon + 180.0) / 360.0 * (1 << Zoom)); }
            
        }
        private int CenterTileY
        {
            get { return (int)((1.0 - Math.Log(Math.Tan(Lat * Math.PI / 180.0) + 1.0 / Math.Cos(Lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << Zoom)); }
            
        }

        public void Render()
        {
            MapRenderer mapRenderer = new MapRenderer(4, 4);
            for (int x = -2; x < 2; x++)
            {
                for (int y = -2; y < 2; y++)
                {
                    Tile tile = this.Layer[this.CenterTileX + x, this.CenterTileY + y, this.Zoom];

                    Console.WriteLine(tile);

                    mapRenderer.Set(x + 2, y + 2, tile.Url);
                }
            }
            mapRenderer.Flush();
            mapRenderer.Render("file.jpg");
        }


    }
}
