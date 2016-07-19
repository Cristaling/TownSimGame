using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    public class ImageProvider
    {

        static Dictionary<TileType, Bitmap> tiles = new Dictionary<TileType, Bitmap>();
        static Dictionary<EntityType, Bitmap> entities = new Dictionary<EntityType, Bitmap>();
        static Bitmap defaultTile = Properties.Resources.Grass32;

        public static void loadTextures()
        {
            tiles.Add(TileType.Dirt, Properties.Resources.Dirt32);
            tiles.Add(TileType.Stone, Properties.Resources.Stone32);
            tiles.Add(TileType.Road, Properties.Resources.Road32);
            entities.Add(EntityType.BuildingBase, Properties.Resources.Building32);
            entities.Add(EntityType.Building, Properties.Resources.Building_H32);
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

        public static Bitmap getEntityTexture(EntityType type)
        {
            Bitmap result;
            if (entities.TryGetValue(type, out result))
            {
                return result;
            }
            return new Bitmap(10, 10);
        }

    }
}
