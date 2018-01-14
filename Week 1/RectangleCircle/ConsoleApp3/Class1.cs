using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Circle
    {
        int radius, diametre;
        double circ, area;

        public Circle()
        {
            radius = 5;
        }

        public Circle(int r)
        {
            radius = r;
        }

        public void FindDiam()
        {
            diametre = 2 * radius;
        }

        public void FindArea()
        {
            area = Math.PI * radius * radius;
        }

        public void FindCirc()
        {
            circ = Math.PI * diametre;
        }

        public override string ToString()
        {
            return "radius = " + radius + "\ndiametre = " + diametre + "\ncircumference = 0" + circ + "\narea = " + area; 
        }
    }
    class Rectangle
    {
        public int width, height;
        public int per, area;

        public double diagonal;

        public Rectangle()
        {
            width = 4;
            height = 8;
        }

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        
        public Rectangle(int c, bool forWidth)
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

        public void FindPer()
        {
            per = 2*(width + height);
        }

        public void FindArea()
        {
            area = width * height;
        }

        public void FindDiagonal()
        {
            diagonal = Math.Sqrt(width * width + height * height);
        }

        public override string ToString()
        {
            return "width = " + width + "\nheight = " + height + "\nperimeter = " + per + "\narea = " + area + "\ndiagonal = " + diagonal;
        }
    }
}
