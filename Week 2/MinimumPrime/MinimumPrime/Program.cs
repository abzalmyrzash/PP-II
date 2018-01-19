using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumPrime
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for(int i = 2; i*i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }


        static void Main(string[] args)
        {
            string path = @"C:\users\abzal\Desktop\PPIILabs\Week 2\MinimumPrime\MinimumPrime\NaborChisel.txt";
            FileStream input = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(input);

            string[] nums = sr.ReadLine().Split(' ');

            int[] primes = new int[nums.Length]; int j = 0;

            for(int i = 0; i < nums.Length; i++){
                int n = int.Parse(nums[i]);
                if (IsPrime(n))
                {
                    primes[j] = n;
                    j++;
                }
            }

            int minPrime = primes[0];

            for(int i = 1; i < j; i++)
            {
                if (primes[i] < minPrime) minPrime = primes[i];
            }

            Console.WriteLine(minPrime);

            Console.ReadKey();
        }
    }
}
