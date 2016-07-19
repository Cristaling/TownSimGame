using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    public class Town
    {

        public List<Entity> entities { get; } = new List<Entity>();
        public List<Tile> tiles { get; } = new List<Tile>();

        int gridSize;

        public Town(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public void sortEntityList()
        {
            entities.Sort();
        }

        public Tile getTileAt(Location loc)
        {
            foreach(Tile tile in tiles)
            {
                if(tile.getLocation() == loc)
                {
                    return tile;
                }
            }
            return null;
        }

        public Entity getEntityAt(Location loc)
        {
            foreach (Entity entity in entities)
            {
                if (entity.location == loc)
                {
                    return entity;
                }
            }
            return null;
        }

        public Location getLocationOnGrid(Location location)
        {
            return new Location(location.x / gridSize * gridSize, location.y / gridSize * gridSize);
        }

    }
}
