using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle(9, true);
            Circle b = new Circle();

            a.FindArea();
            a.FindPer();

            b.FindDiam();
            b.FindCirc();
            b.FindArea();

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
