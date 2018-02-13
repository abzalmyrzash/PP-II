using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public static Snake snake;
        public static Wall wall;
        public static Food food;
        
        public static void Init()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ENTER YOUR USERNAME: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string username = Console.ReadLine();
            bool wrongForFirstTime = true;

            while (username.Length > 16 || username.Length == 0)
            {
                string message = "Please enter a non-empty username with 16 letters!";
                if (wrongForFirstTime)
                {
                    Console.WriteLine(message);
                    wrongForFirstTime = false;
                }
                Console.SetCursorPosition(21, 0);

                for (int i = 0; i < username.Length; i++)
                {
                    Console.Write(' ');
                }

                Console.SetCursorPosition(21, 0);
                username = Console.ReadLine();
            }

            DirectoryInfo dir = new DirectoryInfo(@"C:\Snake Game\usernames\" + username);
            if (!dir.Exists) dir.Create();

            FileInfo highscore = new FileInfo(dir.FullName + @"\highscore.txt");

            if (!highscore.Exists)
            {
                FileStream fs = new FileStream(highscore.FullName, FileMode.Create);
                fs.Close();
                StreamWriter sw = new StreamWriter(highscore.FullName);
                sw.Write(0);
                sw.Close();
            }

            snake = new Snake(username);
            wall = new Wall();
            food = new Food();
        }
    }
}
