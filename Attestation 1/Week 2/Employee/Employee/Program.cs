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
        public double wage;
        private int daysWorked, monthsWorked;
        public bool quitJob = false;

        public Employee(string _name = "Basic Employee", double _wage = 500)
        {
            name = _name;
            wage = _wage;
            daysWorked = 0;
        }

        public void Work()
        {
            int daysBefore = daysWorked, monthsBefore;
            ConsoleKeyInfo btn = Console.ReadKey();
            if (btn.Key == ConsoleKey.W) daysWorked++;
            if (btn.Key == ConsoleKey.Escape) quitJob = true;

            monthsWorked = daysWorked / 30;
            monthsBefore = daysBefore / 30;

            if(monthsWorked - monthsBefore == 1) wage = wage * 1.02;
        }

        public double Wage
        {
            get { return wage; }
            set { if (value >= 0) wage = value; }
        }

        public override string ToString()
        {
            return "Name: " + name + "\nSalary: " + wage + "\nDays Worked: " + daysWorked + "\nQuit Job: " + quitJob;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Employee e = new Employee(name);

            e.Wage = 600;

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
