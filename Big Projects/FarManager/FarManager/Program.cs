using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace FarManager
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DirectoryInfo dir = new DirectoryInfo(@"C:\Far Manager Folder");
            DirectoryInfo[] dirs = dir.GetDirectories();*/
            Process.Start(@"C:\Test\test1.txt");
            Console.ReadKey();
        }
    }
}
