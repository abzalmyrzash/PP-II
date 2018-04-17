using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Test\file.txt");
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null) break;
                if (line.Length > 3)
                {
                    for (int i = 0; i < line.Length - 3; i++)
                    {
                        if(line.Substring(i, 4) == "KBTU")
                        {
                            DirectoryInfo dir = new DirectoryInfo("C:\\Test");
                            foreach(FileInfo f in dir.GetFiles())
                            {
                                if(f.Name.Substring(f.Name.Length - 4, 4) == ".txt") Console.WriteLine(f.Name);
                            }
                            break;
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
