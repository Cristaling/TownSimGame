using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    public enum TileType
    {
        None,
        Dirt,
        Stone,
        Road
    }

    class Tile
    {

        Location location;
        public TileType type { get; set; }

        public Tile(Location location, TileType type)
        {
            this.location = location;
            this.type = type;
        }

        public Location getLocation()
        {
            return location;
        }

    }
}
