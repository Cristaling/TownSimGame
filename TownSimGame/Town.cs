using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    class Town
    {

        List<Entity> entities = new List<Entity>();
        List<Tile> tiles = new List<Tile>();

        int gridSize;

        public Town(int gridSize)
        {
            this.gridSize = gridSize;
        }

        public List<Tile> getTiles()
        {
            return tiles;
        }

        public List<Entity> getEntities()
        {
            return entities;
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
                if (entity.getLocation() == loc)
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
