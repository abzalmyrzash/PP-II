using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = { "Hello ", "World! ", "My name is ", "Abzal!" };
            string content = null;
            StreamWriter sw = new StreamWriter(@"C:\test\just.txt");
            /*foreach (string line in lines)
            {
                Console.WriteLine(line);
                content += line;
            }*/
            sw.Write("Hello \nWorld!");
            
            sw.Close();
            Console.ReadKey();
        }
    }
}
