using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    class ImageProvider
    {

        static Dictionary<TileType, Bitmap> tiles = new Dictionary<TileType, Bitmap>();
        static Bitmap defaultTile = Properties.Resources.Grass32;

        public static void loadTextures()
        {
            tiles.Add(TileType.Dirt, Properties.Resources.Dirt32);
            tiles.Add(TileType.Stone, Properties.Resources.Stone32);
            tiles.Add(TileType.Road, Properties.Resources.Road32);
        }

        public static Bitmap getTileTexture(TileType type)
        {
            Bitmap result;
            if(tiles.TryGetValue(type, out result))
            {
                return result;
            }
            return defaultTile;
        }

    }
}
