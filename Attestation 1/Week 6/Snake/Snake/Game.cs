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
        public static bool pause, exit, Over;

        public Game()
        {

        }

        public static void Init()
        {
            exit = Over = false;
            pause = true;

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

            string path = @"C:\snake game\usernames\" + username + "\\saves";
            DirectoryInfo directory = new DirectoryInfo(path);
            Console.ForegroundColor = ConsoleColor.Cyan;

            List<string> options = new List<string>();
            options.Add("New game");
            if (directory.Exists && directory.GetDirectories().Length > 0) options.Add("Load game");
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

                if (options[option] == "Load game")
                {
                    Console.Clear();
                    string saveName;
                    Console.WriteLine("Load game\n");

                    DirectoryInfo dir = new DirectoryInfo(path);
                    DirectoryInfo[] dirs = dir.GetDirectories();

                    for(int i = 0; i < dirs.Length; i++)
                    {
                        for(int j = i + 1; j < dirs.Length; j++)
                        {
                            if (dirs[i].CreationTime < dirs[j].CreationTime)
                            {
                                DirectoryInfo d = dirs[j];
                                dirs[j] = dirs[i];
                                dirs[i] = d;
                            }
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    for(int i = 0; i < dirs.Length; i++)
                    {
                        Console.WriteLine(dirs[i].Name);
                    }
                    int saveNum = 0;

                    while (true)
                    {
                        Console.SetCursorPosition(0, 2 + saveNum);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine(dirs[saveNum]);

                        int prevSaveNum = saveNum;
                        ConsoleKey key = Console.ReadKey(true).Key;
                        switch (key)
                        {
                            case ConsoleKey.UpArrow:
                                if (saveNum > 0) saveNum--;
                                break;
                            case ConsoleKey.DownArrow:
                                if (saveNum < dirs.Length - 1) saveNum++;
                                break;
                        }

                        if (key == ConsoleKey.Enter) break;

                        Console.SetCursorPosition(0, 2 + prevSaveNum);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(dirs[prevSaveNum]);
                    }

                    saveName = dirs[saveNum].Name;

                    Console.Clear();

                    path += "\\" + saveName;

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

                    Console.BackgroundColor = ConsoleColor.Black;
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
            Console.Clear();
            string path = @"C:\Snake Game\usernames\" + snake.username + @"\saves\";
            string saveName;
            if (!new DirectoryInfo(path).Exists) new DirectoryInfo(path).Create();

            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories(); for (int i = 0; i < dirs.Length; i++)
            {
                for (int j = i + 1; j < dirs.Length; j++)
                {
                    if (dirs[i].CreationTime < dirs[j].CreationTime)
                    {
                        DirectoryInfo d = dirs[j];
                        dirs[j] = dirs[i];
                        dirs[i] = d;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Save the game");
            
            for (int i = 0; i < dirs.Length; i++)
            {
                Console.WriteLine(dirs[i].Name);
            }

            int saveNum = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 2 + saveNum);
                Console.BackgroundColor = ConsoleColor.White;
                if (saveNum > 0) Console.WriteLine(dirs[saveNum - 1]);
                else Console.WriteLine("Create new save");

                int prevSaveNum = saveNum;
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (saveNum > 0) saveNum--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (saveNum < dirs.Length - 1) saveNum++;
                        break;
                }

                if (key == ConsoleKey.Enter) break;

                Console.SetCursorPosition(0, 2 + prevSaveNum);
                Console.BackgroundColor = ConsoleColor.Black;
                if (prevSaveNum > 0) Console.WriteLine(dirs[prevSaveNum - 1]);
                else Console.WriteLine("Save the game");
            }

            Console.BackgroundColor = ConsoleColor.Black; 

            if (saveNum > 0) saveName = dirs[saveNum - 1].Name;
            else
            {
                Console.Clear();
                Console.WriteLine("Write name of new save\n");
                string s;

                while (true)
                {
                    Console.SetCursorPosition(0, 2);
                    s = Console.ReadLine();

                    Console.SetCursorPosition(0, 4);
                    if (s == "" || s.Length > 16)
                    {
                        Console.WriteLine("Enter a non-empty string with no more than 16 letters!");
                    }
                    else if (new DirectoryInfo(path + s).Exists)
                    {
                        Console.WriteLine("Save already exists!");
                    }
                    else break;
                }

                saveName = s;
            }

            path += saveName;
            Directory.CreateDirectory(path);

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

        public static void CheckGameOver()
        {
            if (Game.snake.CollisionWithItself() || Game.snake.CollisionWithWall())
            {
                Over = true;

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
                    if (i < 10) sw.WriteLine(i + 1 + ")" + (i + 1 == 10 ? " " : "  ") + scores[i]);
                    else break;
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
                        if (option == 1) exit = true;
                        else Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                }
                
                if (!exit)
                {
                    Console.Clear();
                    Program.Main(null);
                }
            }
        }
        
        public static void Draw()
        {
            snake.Draw();
            wall.Draw();
            food.Draw();
            Program.ShowScore();
            Program.FindSpeed();
        }
    }
}
