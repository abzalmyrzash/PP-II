using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static int Factorial(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            return Factorial(n - 1) * n;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
            Console.ReadKey(true);
        }
    }
}
