using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Snake
{ 
    class Program
    {
        static void DrawFrame()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            for(int i = 0; i < 72; i++)
            {
                Console.Write('*');
            }

            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine();
                Console.Write('*');
                Console.SetCursorPosition(71, i + 1);
                Console.Write('*');
            }

            Console.WriteLine();

            for(int i = 0; i < 72; i++)
            {
                Console.Write('*');
            }
        }

        static void ShowScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Score: " + Game.snake.score);
            Console.Write("Highscore: " + Game.snake.highscore);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            bool exit = false;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.Clear();

                Game.Init();
                Console.Clear();

                DrawFrame();
                Game.wall.Draw();

                while (true)
                {
                    ShowScore();
                    Game.snake.Draw();
                    Game.food.Draw();

                    ConsoleKeyInfo btn = Console.ReadKey(true);

                    switch (btn.Key)
                    {
                        case ConsoleKey.W:
                            Game.snake.Move(0, -1);
                            break;
                        case ConsoleKey.S:
                            Game.snake.Move(0, 1);
                            break;
                        case ConsoleKey.A:
                            Game.snake.Move(-1, 0);
                            break;
                        case ConsoleKey.D:
                            Game.snake.Move(1, 0);
                            break;
                    }

                    if (Game.snake.body[0].x > 69) Game.snake.body[0].x = 0;
                    else if (Game.snake.body[0].x < 0) Game.snake.body[0].x = 69;

                    if (Game.snake.body[0].y > 19) Game.snake.body[0].y = 0;
                    else if (Game.snake.body[0].y < 0) Game.snake.body[0].y = 19;

                    if (Game.snake.AteFood())

                        Game.food.SetRandomPosition();

                    if (Game.snake.CollisionWithItself() || Game.snake.CollisionWithWall())
                    {
                        bool highscrbeated = false;
                        if (Game.snake.score > Game.snake.highscore)
                        {
                            string path = @"C:\Snake Game\usernames\" + Game.snake.username + @"\highscore.txt";
                            FileStream highscore = new FileStream(path, FileMode.Open);
                            StreamWriter sw = new StreamWriter(highscore);
                            sw.Write(Game.snake.score);
                            sw.Close();
                            highscrbeated = true;
                        }

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
                        break;
                    }
                }
                if (exit) break;
            }
        }
    }
}
