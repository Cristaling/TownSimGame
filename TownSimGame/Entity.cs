using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    public enum EntityType
    {
        None,
        BuildingBase,
        Building,
        Person
    }

    public abstract class Entity : IComparable<Entity>
    {

        public Location location { get; }

        public Entity(Location location)
        {
            this.location = location;
        }

        public int CompareTo(Entity entity)
        {
            if(entity.location.y > location.y)
            {
                return -1;
            }else if(entity.location.y < location.y)
            {
                return 1;
            }
            return 0;
        }

        public abstract void draw(Graphics gr);

    }
}
