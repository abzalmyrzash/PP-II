using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\abzal\desktop\PPIILabs\Week 2\MaxMin\MaxMin\NaborChisel.txt";

            //FileInfo file = new FileInfo(path);
            //FileStream inputfile = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(path);

            string[] numbers = sr.ReadLine().Split(' ');
            int max, min = max = int.Parse(numbers[0]);

            for(int i = 1; i < numbers.Length; i++)
            {
                int n = int.Parse(numbers[i]);

                if (n > max) max = n;
                if (n < min) min = n;
            }

            Console.WriteLine("The greatest number is " + max);
            Console.WriteLine("The least number is " + min);

            Console.ReadKey();
        }
    }
}
