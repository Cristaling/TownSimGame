using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownSimGame
{
    public class Location
    {

        public int x { get; set; }
        public int y { get; set; }

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Location a, Location b)
        {
            if(System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return (a.x == b.x && a.y == b.y);
        }

        public static bool operator !=(Location a, Location b)
        {
            return !(a == b);
        }

    }
}
