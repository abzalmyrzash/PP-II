using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Clock
{
    class Hand
    {
        public int radius;
        private int angle;
        public Pen pen;

        public Hand(int radius, Color color, int width)
        {
            pen = new Pen(color, width);
            this.radius = radius;
        }

        public int Angle
        {
            get { return angle; }
            set { angle = value; }
        }
    }
}
