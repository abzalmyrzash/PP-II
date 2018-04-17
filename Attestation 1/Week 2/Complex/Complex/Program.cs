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

            Complex c3 = c1 + c2;

            Console.Clear();

            Console.WriteLine(" " + c1 + "\n+\n " + c2);

            int l1 = c1.GetString().Length, l2 = c2.GetString().Length, l3 = c3.GetString().Length, best = l1;

            if (l3 >= l1 && l3 >= l2) best = l3;
            else if (l2 >= l1 && l2 >= l3) best = l2;

            for(int i = 0; i <= best; i++)
            {
                Console.Write('_');
            }

            Console.Write("\n " + c3);

            Console.ReadKey();
        }
    }
}
