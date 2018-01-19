using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values1 = Console.ReadLine().Split(' ');

            string[] values2 = Console.ReadLine().Split(' ');

            Complex c1 = new Complex(int.Parse(values1[0]), int.Parse(values1[1]));
            Complex c2 = new Complex(int.Parse(values2[0]), int.Parse(values2[1]));

            Console.WriteLine(c1 + c2);

            Console.ReadKey();
        }
    }
}
