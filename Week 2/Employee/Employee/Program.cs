using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{

    class Employee
    {
        public string name;
        public int wage;
        double w;
        public int initialWage;
        private int daysWorked;
        public bool quitJob = false;

        public Employee(string _name = "Basic Employee", int _wage = 500)
        {
            name = _name;
            initialWage = _wage;
            daysWorked = 0;
        }

        public void Work()
        {
            ConsoleKeyInfo btn = Console.ReadKey();
            if (btn.Key == ConsoleKey.W) daysWorked++;
            else if (btn.Key == ConsoleKey.Escape) quitJob = true;
        }

        private void Wage()
        {
            int monthWorked = daysWorked / 30;
            double coefficient = Math.Pow(1.02, monthWorked);
            w = initialWage * coefficient;
            wage = Convert.ToInt32(w);
        }

        public override string ToString()
        {
            Wage();
            return "Name: " + name + "\nSalary: " + wage + "\nDays Worked: " + daysWorked + "\nQuit Job: " + quitJob;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            Console.WriteLine(e);
            while (!e.quitJob)
            {
                e.Work();
                Console.Clear();
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
