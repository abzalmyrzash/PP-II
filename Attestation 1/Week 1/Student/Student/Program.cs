using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{

    class Student
    {
        public string university, faculty, name, surname;
        public int year;
        public double gpa;
        public Student()
        {
            university = "KBTU";
            faculty = "FIT";
            name = "KBTUshnik";
            surname = "Pervokursnikov";
            year = 1;
            gpa = 3.67;
        }
        public Student(string university, string faculty, string name, string surname, int year, double gpa)
        {
            this.university = university;
            this.faculty = faculty;
            this.name = name;
            this.surname = surname;
            this.year = year;
            this.gpa = gpa;
        }
        public override string ToString()
        {
            return university + " " + faculty + '\n' + name + " " + surname + "\n Year " + year + "      GPA " + gpa + '\n';
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Student s2 = new Student("KazGU", "Economics", "Oleg", "Ivankov", 3, 3.71);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.ReadKey();
        }
    }
}
