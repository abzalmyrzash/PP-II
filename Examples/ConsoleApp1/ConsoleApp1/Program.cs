using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        public double wage;
        public Employee(int w)
        {
            wage = w;
        }

        public Employee(double w)
        {
            wage = w + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //int w = int.Parse(Console.ReadLine());

            Employee e = new Employee(5);

            Console.WriteLine(e.wage);

            Console.ReadKey();
            
        }
    }
}
