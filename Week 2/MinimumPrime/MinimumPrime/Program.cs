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
            string path1 = @"C:\users\abzal\Desktop\PPIILabs\Week 2\MinimumPrime\MinimumPrime\NaborChisel.txt";
            string path2 = @"C:\users\abzal\Desktop\PPIILabs\Week 2\MinimumPrime\MinimumPrime\Otvet.txt";

            FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs1);

            FileStream fs2 = new FileStream(path2, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);

            string[] nums = sr.ReadLine().Split(' ');
            sr.Close();

            int[] primes = new int[nums.Length]; int j = 0;

            bool ok = false;

            for(int i = 0; i < nums.Length; i++){
                int n = int.Parse(nums[i]);
                if (IsPrime(n))
                {
                    primes[j] = n;
                    j++;
                    ok = true;
                }
            }

            if (ok)
            {
                int minPrime = primes[0];

                for (int i = 1; i < j; i++)
                {
                    if (primes[i] < minPrime) minPrime = primes[i];
                }


                sw.WriteLine("Minimum Prime is " + minPrime);
                sw.Close();
            }

            else sw.WriteLine("There are no primes!");
            sw.Close();
        }
    }
}
