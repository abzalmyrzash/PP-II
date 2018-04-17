using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            Console.WriteLine("Highscore: " + Game.snake.highscore);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.Clear();

                Game.Init();
                if (Game.exit) break;
                Console.Clear();

                DrawFrame();
                Game.wall.Draw();

                Game.snake.direction = 0;
                bool MainMenu = false;

                while (!Game.exit && !MainMenu)
                {
                    if (Game.pause)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("Your game is paused.");
                    }
                    else
                    {
                        Game.food.Draw();
                        Game.snake.Draw();
                        ShowScore();
                    }
                    Thread.Sleep(100);

                    while (true)
                    {
                        bool tryagain = false;
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo btn = Console.ReadKey(true);

                            if (btn.Key != ConsoleKey.P)
                            {
                                Game.pause = false;
                                switch (btn.Key)
                                {
                                    case ConsoleKey.W:
                                        if (Game.snake.direction != 1 && Game.snake.direction != 2)
                                            Game.snake.direction = 1;
                                        else tryagain = true;
                                        break;
                                    case ConsoleKey.S:
                                        if (Game.snake.direction != 1 && Game.snake.direction != 2)
                                            Game.snake.direction = 2;
                                        else tryagain = true;
                                        break;
                                    case ConsoleKey.A:
                                        if (Game.snake.direction != 3 && Game.snake.direction != 4)
                                            Game.snake.direction = 3;
                                        else tryagain = true;
                                        break;
                                    case ConsoleKey.D:
                                        if (Game.snake.direction != 3 && Game.snake.direction != 4)
                                            Game.snake.direction = 4;
                                        else tryagain = true;
                                        break;
                                    case ConsoleKey.Escape:

                                        Console.Clear();
                                        if (!Game.pause)
                                        {
                                            Game.pause = true;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("GAME PAUSE");
                                            int option = 0;
                                            string[] options = { "Resume", "Go to main menu", "Exit the game" };

                                            while (true)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("GAME PAUSE");
                                                Game.pause = true;

                                                for (int i = 0; i < 3; i++)
                                                {
                                                    if (option == i) Console.BackgroundColor = ConsoleColor.White;
                                                    else Console.BackgroundColor = ConsoleColor.Black;

                                                    Console.WriteLine(options[i]);
                                                }
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch (key)
                                                {
                                                    case ConsoleKey.UpArrow:
                                                        if (option > 0) option--;
                                                        break;
                                                    case ConsoleKey.DownArrow:
                                                        if (option < 2) option++;
                                                        break;
                                                }
                                                if (key == ConsoleKey.Enter)
                                                {
                                                    if (option == 0)
                                                    {
                                                        Console.Clear();
                                                        DrawFrame();
                                                        Game.snake.Draw();
                                                        Game.wall.Draw();
                                                        Game.food.Draw();
                                                        ShowScore();
                                                    }

                                                    else if (option == 1)
                                                    {
                                                        MainMenu = true;
                                                    }

                                                    else Game.exit = true;
                                                    break;
                                                }

                                                if (key == ConsoleKey.Escape)
                                                {
                                                    Console.Clear();
                                                    DrawFrame();
                                                    Game.snake.Draw();
                                                    Game.wall.Draw();
                                                    Game.food.Draw();
                                                    ShowScore();
                                                    break;
                                                }
                                            }
                                        }

                                        break;
                                }
                            }
                            else Game.pause = true;
                        }


                        if (!tryagain) break;
                    }

                    if (!Game.pause)
                    {
                        Game.snake.Move(Game.snake.direction);

                        if (Game.snake.body[0].x > 69) Game.snake.body[0].x = 0;
                        else if (Game.snake.body[0].x < 0) Game.snake.body[0].x = 69;

                        if (Game.snake.body[0].y > 19) Game.snake.body[0].y = 0;
                        else if (Game.snake.body[0].y < 0) Game.snake.body[0].y = 19;

                        if (Game.snake.AteFood())

                            Game.food.SetRandomPosition();

                        if(Game.CheckGameOver()) break;
                        
                    }
                }
                if (Game.exit) break;
            }
        }
    }
}
