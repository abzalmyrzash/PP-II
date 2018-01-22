using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void ShowDF(string path)
        {
            int depth = 0, n = 0;
            Stack<DirectoryInfo> MyStack = new Stack<DirectoryInfo>();
            DirectoryInfo dir = new DirectoryInfo(path);
            MyStack.Push(dir);

            Console.WriteLine(dir.Name);

            for(int i = 0; i < path.Length; i++)
                if (path[i] == '\\') n++;

            while (MyStack.Count > 0)
            {
                DirectoryInfo dir2 = MyStack.Pop();
                DirectoryInfo[] d = dir2.GetDirectories();

                string path2 = dir2.FullName;

                int m = 0;
                for (int i = 0; i < path2.Length; i++)
                    if (path2[i] == '\\') m++;

                depth = m - n + 1;

                for(int i = 0; i < d.Length; i++)
                {
                    MyStack.Push(d[d.Length - i - 1]);

                    for(int j = 0; j < depth * 5; j++) Console.Write(' ');

                    Console.WriteLine(d[i].Name);
                }

                foreach (FileInfo f in dir2.GetFiles())
                {
                    for(int i = 0; i < depth * 5; i++) Console.Write(' ');
                    
                    Console.WriteLine(f.Name);
                }
            }
        }

        /*static void ShowStackTree(string path)
        {
            Stack<DirectoryInfo> myS = new Stack<DirectoryInfo>();
            DirectoryInfo dir = new DirectoryInfo(path);
            myS.Push(dir);

            while (myS.Count > 0)
            {
                DirectoryInfo cur = myS.Pop();
                foreach (DirectoryInfo d in cur.GetDirectories())
                {
                    Console.WriteLine(d.Name);
                    myS.Push(d);
                }

                foreach (FileInfo f in cur.GetFiles())
                {
                    Console.WriteLine(f.Name);
                }
            }

        }*/

        static void Main(string[] args)
        {
            string path = @"C:\test";

            ShowDF(path);

            //ShowStackTree(path);

            Console.ReadKey();
        }
    }
}
