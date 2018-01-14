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
            rectangle a = new rectangle(9, true);
            circle b = new circle();

            a.findArea();
            a.findPer();

            b.findDiam();
            b.findCirc();
            b.findArea();

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}
