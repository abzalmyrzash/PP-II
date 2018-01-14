using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class circle
    {
        int radius, diametre;
        double circ, area;

        public circle()
        {
            radius = 5;
        }

        public circle(int r)
        {
            radius = r;
        }

        public void findDiam()
        {
            diametre = 2 * radius;
        }

        public void findArea()
        {
            area = Math.PI * radius * radius;
        }

        public void findCirc()
        {
            circ = Math.PI * diametre;
        }

        public override string ToString()
        {
            return "radius = " + radius + "\ndiametre = " + diametre + "\ncircumference = 0" + circ + "\narea = " + area; 
        }
    }
    class rectangle
    {
        public int width, height;
        public int per, area;

        public rectangle()
        {
            width = 4;
            height = 8;
        }

        public rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        
        public rectangle(int c, bool forWidth)
        {
            if (forWidth)
            {
                width = c;
                height = 15;
            }
            else{
                height = c;
                width = 15;
            }
        }

        public void findPer()
        {
            per = 2*(width + height);
        }

        public void findArea()
        {
            area = width * height;
        }

        public override string ToString()
        {
            return "width = " + width + "\nheight = " + height + "\nperimeter = " + per + "\narea = " + area;
        }
    }
}
