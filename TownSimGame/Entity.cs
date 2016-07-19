using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    abstract class Entity : IComparable<Entity>
    {

        Location location;

        public Entity(Location location)
        {
            this.location = location;
        }

        public int CompareTo(Entity entity)
        {
            if(entity.location.y > location.y)
            {
                return 1;
            }else if(entity.location.y < location.y)
            {
                return -1;
            }
            return 0;
        }

        public Location getLocation()
        {
            return location;
        }

        public abstract void draw(Graphics gr);

    }
}
