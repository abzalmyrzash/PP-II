using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    [Serializable]
    public class Game
    {
        public static Snake snake;
        public static Wall wall;
        public static Food food;
        public static bool pause;
        public static bool exit;

        public Game()
        {

        }

        public static void Init()
        {
            pause = false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ENTER YOUR USERNAME: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string username = Console.ReadLine();
            bool wrongForFirstTime = true;
            string message = "Please enter a non-empty username with no more than 16 letters!";

            while (username.Length > 16 || username.Length == 0)
            {
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

            string path = @"C:\snake game\usernames\" + username + "\\gamestats";
            DirectoryInfo directory = new DirectoryInfo(path);
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<string> options = new List<string>();
            if (directory.Exists) options.Add("Resume game");
            options.Add("New game");
            if (new FileInfo(@"C:\snake game\usernames\" + username + "\\highscores.txt").Exists) options.Add("List of highscores");
            options.Add("Exit");
            int option = 0;

            while (true)
            {
                bool resumeCycle = false;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("MAIN MENU\n");
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.BackgroundColor = i == option ? ConsoleColor.White : ConsoleColor.Black;
                        Console.WriteLine(options[i]);
                    }

                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            if (option > 0) option--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (option < options.Count - 1) option++;
                            break;
                    }

                    if (key == ConsoleKey.Enter) break;
                }

                if (options[option] == "Resume game")
                {
                    string fSnake = path + "\\snake.xml";
                    string fWall = path + "\\wall.xml";
                    string fFood = path + "\\food.xml";

                    FileStream fs = new FileStream(fSnake, FileMode.Open);
                    snake = new XmlSerializer(typeof(Snake)).Deserialize(fs) as Snake;
                    fs.Close();

                    fs = new FileStream(fWall, FileMode.Open);
                    wall = new XmlSerializer(typeof(Wall)).Deserialize(fs) as Wall;
                    fs.Close();

                    fs = new FileStream(fFood, FileMode.Open);
                    food = new XmlSerializer(typeof(Food)).Deserialize(fs) as Food;
                    fs.Close();
                }

                else if (options[option] == "New game")
                {
                    DirectoryInfo dir = new DirectoryInfo(@"C:\Snake Game\usernames\" + username);
                    if (!dir.Exists) dir.Create();

                    FileStream highscore = new FileStream(dir.FullName + @"\highscores.txt", FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(highscore);
                    string line = sr.ReadLine();
                    sr.Close();

                    if (line == null)
                    {
                        StreamWriter sw = new StreamWriter(dir.FullName + @"\highscores.txt");
                        sw.Write("1)  " + 0);
                        sw.Close();
                    }
                    highscore.Close();

                    snake = new Snake(username);
                    wall = new Wall();
                    food = new Food();
                }

                else if (options[option] == "List of highscores")
                {
                    Console.Clear();
                    string hsPath = @"C:\snake game\usernames\" + username + "\\highscores.txt";
                    StreamReader sr = new StreamReader(hsPath);
                    Console.Write(sr.ReadToEnd());
                    sr.Close();

                    while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }

                    resumeCycle = true;
                }
                else if (options[option] == "Exit")
                {
                    exit = true;
                }
                if (!resumeCycle) break;
            }
        }

        public static void Save()
        {
            string path = @"C:\Snake Game\usernames\" + snake.username + "\\gamestats";
            if (!new DirectoryInfo(path).Exists) new DirectoryInfo(path).Create();
            string fSnake = path + "\\snake.xml";
            string fWall = path + "\\wall.xml";
            string fFood = path + "\\food.xml";

            FileStream fs = new FileStream(fSnake, FileMode.OpenOrCreate);
            new XmlSerializer(typeof(Snake)).Serialize(fs, snake);
            fs.Close();

            fs = new FileStream(fWall, FileMode.OpenOrCreate);
            new XmlSerializer(typeof(Wall)).Serialize(fs, wall);
            fs.Close();

            fs = new FileStream(fFood, FileMode.OpenOrCreate);
            new XmlSerializer(typeof(Food)).Serialize(fs, food);
            fs.Close();
        }

        public static bool CheckGameOver()
        {
            if (Game.snake.CollisionWithItself() || Game.snake.CollisionWithWall())
            {
                string path = @"C:\snake game\usernames\" + Game.snake.username + "\\gamestats";
                if (Directory.Exists(path)) Directory.Delete(path, true);

                bool highscrbeated = false;
                if (Game.snake.score > Game.snake.highscore)
                    highscrbeated = true;

                string path2 = @"C:\snake game\usernames\" + Game.snake.username + "\\highscores.txt";

                FileStream fs = new FileStream(path2, FileMode.OpenOrCreate);
                fs.Close();
                StreamReader sr = new StreamReader(path2);

                List<int> scores = new List<int>();
                string line;
                bool found = false;

                while (true)
                {
                    line = sr.ReadLine();
                    if (line == null)
                    {
                        if(!found) scores.Add(Game.snake.score);
                        break;
                    }
                    int score = int.Parse(line.Remove(0, 4));
                    if (Game.snake.score >= score && !found)
                    {
                        scores.Add(Game.snake.score);
                        if(score != Game.snake.score) scores.Add(score);
                        found = true;
                    }
                    else scores.Add(score);
                }

                sr.Close();
                StreamWriter sw = new StreamWriter(path2);

                for (int i = 0; i < scores.Count; i++)
                {
                    if(i <= 10) sw.WriteLine(i + 1 + ")" + (i + 1 == 10 ? " " : "  ") + scores[i]);
                }
                sw.Close();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("GAME OVER!");
                Thread.Sleep(500);

                Console.Write("Score: ");
                Thread.Sleep(500);

                Console.Write(Game.snake.score);

                if (highscrbeated)
                {
                    Thread.Sleep(500);
                    Console.Write("     NEW HIGHSCORE!");
                }
                Thread.Sleep(500);

                Console.WriteLine();
                Console.WriteLine("Highscore: " + Game.snake.highscore);

                Console.WriteLine("Do you want to retry?");
                int option = 1;
                bool chosen = false;

                ConsoleColor selected = ConsoleColor.White;
                ConsoleColor unselected = ConsoleColor.Black;

                while (true)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.BackgroundColor = option == 1 ? selected : unselected;
                    Console.WriteLine("Exit");
                    Console.BackgroundColor = option == 2 ? selected : unselected;
                    Console.WriteLine("Retry");

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (option != 1) option--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (option != 2) option++;
                            break;
                        case ConsoleKey.Enter:
                            chosen = true;
                            break;
                    }

                    if (!chosen)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("    ");
                        Console.Write("     ");
                    }

                    else
                    {
                        if (option == 1) Game.exit = true;
                        else Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
