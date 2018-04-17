using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFarManager
{
    class Program
    {

        static void ShowState(DirectoryInfo dir, int pos)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine(dir.FullName);
          
            DirectoryInfo[] d = dir.GetDirectories();
            FileInfo[] f = dir.GetFiles();

            int n = d.Length, m = f.Length;

            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < n; i++)
            {
                Console.BackgroundColor = pos == i ? ConsoleColor.White : ConsoleColor.Black;
                Console.WriteLine(d[i].Name);
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < m; i++)
            {
                Console.BackgroundColor = pos == i + n ? ConsoleColor.White : ConsoleColor.Black;
                Console.WriteLine(f[i].Name);
            }
        }


        static int Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;
            bool fileOpenedAlready = false;
            bool fileIsOpen = false;

            DirectoryInfo dir = new DirectoryInfo(@"C:\Test");

            while (true)
            {
                bool ok = true;
                if (!fileIsOpen)
                {
                    Console.Clear();
                    ShowState(dir, pos);
                }
                ConsoleKeyInfo btn = Console.ReadKey();
                switch (btn.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                            pos = dir.GetFileSystemInfos().Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos >= dir.GetFileSystemInfos().Length)
                            pos = 0;
                        break;
                    case ConsoleKey.Enter:
                        DirectoryInfo[] d = dir.GetDirectories();
                        FileInfo[] f = dir.GetFiles();
                        if (pos < d.Length)
                        {
                            dir = new DirectoryInfo(d[pos].FullName);
                            pos = 0;
                        }
                        else if(f.Length != 0)
                        {
                            string content = null, path2 = f[pos - d.Length].FullName;
                            fileIsOpen = true;

                            while (fileIsOpen)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;

                                if (!fileOpenedAlready)
                                {
                                    Console.Clear();
                                    if (content == null)
                                    {
                                        StreamReader sr = new StreamReader(path2);
                                        content = sr.ReadToEnd();
                                        sr.Close();
                                    }

                                    Console.Write(content);
                                }

                                fileOpenedAlready = true;

                                Console.CursorVisible = true;

                                ConsoleKeyInfo key = Console.ReadKey(true);

                                while (key.Key != ConsoleKey.Escape)
                                {
                                    if (key.Key == ConsoleKey.Backspace)
                                    {
                                        if (content.Length != 0)
                                        {
                                            content = content.Remove(content.Length - 1);
                                            Console.Clear();
                                            Console.Write(content);
                                        }
                                    }

                                    else if (key.Key == ConsoleKey.Enter)
                                    {
                                        Console.WriteLine();
                                        content += '\n';
                                    }

                                    else
                                    {
                                        content += key.KeyChar;
                                        Console.Write(key.KeyChar);
                                    }

                                    key = Console.ReadKey(true);
                                }

                                Console.CursorVisible = false;

                                int option = 0;
                                string[] options = { "Yes", "No", "I don't want to quit editing" };

                                while (true)
                                {
                                    Console.Clear();

                                    Console.ForegroundColor = ConsoleColor.Yellow;

                                    Console.WriteLine("Do you want to save changes?\n");

                                    for (int i = 0; i <= 2; i++)
                                    {
                                        if (i == 0) Console.ForegroundColor = ConsoleColor.Green;
                                        else if (i == 1) Console.ForegroundColor = ConsoleColor.Red;
                                        else Console.ForegroundColor = ConsoleColor.Blue;

                                        Console.BackgroundColor = i == option ? ConsoleColor.White : ConsoleColor.Black;
                                        Console.WriteLine(options[i]);
                                    }

                                    ConsoleKeyInfo key2 = Console.ReadKey(true);

                                    switch (key2.Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            if (option != 0) option--;
                                            else option = 2;
                                            break;

                                        case ConsoleKey.DownArrow:
                                            if (option != 2) option++;
                                            else option = 0;
                                            break;
                                    }

                                    if (key2.Key == ConsoleKey.Enter) break;
                                }

                                if (option < 2)
                                {
                                    if (option == 0)
                                    {
                                        StreamWriter sw = new StreamWriter(path2);
                                        for(int i = 0; i < content.Length; i++)
                                        {
                                            if (content[i] == '\n') sw.WriteLine();
                                            else sw.Write(content[i]);
                                        }
                                        sw.Close();
                                    }

                                    fileIsOpen = fileOpenedAlready = false;
                                }

                                else fileOpenedAlready = false;
                            }
                        }
                        break;

                    case ConsoleKey.Escape:

                        if (!fileIsOpen)
                        {

                            ok = false;

                            string s = dir.FullName;
                            for (int i = s.Length - 1; i > 0; i--)
                            {
                                if (s[i] == '\\')
                                {
                                    if (s != @"C:\")
                                    {
                                        string t = s.Remove(i + 1);
                                        if (t == @"C:\") s = t;
                                        else s = s.Remove(i);
                                        ok = true;
                                        break;
                                    }
                                }
                            }

                            if (ok)
                            {
                                DirectoryInfo dir2 = dir;
                                dir = new DirectoryInfo(s);
                                DirectoryInfo[] dirs = dir.GetDirectories();
                                for (int i = 0; i < dirs.Length; i++)
                                {
                                    if (dir2.FullName == dirs[i].FullName)
                                    {
                                        pos = i;
                                        break;
                                    }
                                }
                            }

                            //dir = dir.Parent;
                        }

                        break;
                }
                if (!ok) return 0;
            }
        }
    }
}