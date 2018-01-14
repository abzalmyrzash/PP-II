using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static bool isPrime(int n)
        {
            for(int i = 2; i*i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                int n = int.Parse(args[i]);
                if (isPrime(n)) Console.WriteLine(n + " ");
            }
            Console.ReadKey();
        }
    }
}
