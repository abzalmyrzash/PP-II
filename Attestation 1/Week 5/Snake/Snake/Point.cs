using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Point
    {
        public int x, y;

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public Point()
        {

        }

        public override string ToString()
        {
            return x + " " + y;
        }
    }
}
