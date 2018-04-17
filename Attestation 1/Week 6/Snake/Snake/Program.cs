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

        public static void ShowScore()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("Score: " + Game.snake.score);
            Console.WriteLine("Highscore: " + Game.snake.highscore);
        }

        public static void FindSpeed()
        {
            if (Game.snake.speed > 75)
            {
                Game.snake.speed = 150 - 5 * (Game.snake.score / 20);
            }

            Console.SetCursorPosition(50, 25);
            Console.Write("Time wasted to make one step: " + Game.snake.speed + " milliseconds + const");
        }

        static void DrawMove()
        {
            while (true)
            {
                if (!Game.pause)
                {
                    Game.snake.Move(Game.snake.direction);

                    Thread.Sleep(Game.snake.speed);

                    if (Game.snake.body[0].x > 69) Game.snake.body[0].x = 0;
                    else if (Game.snake.body[0].x < 0) Game.snake.body[0].x = 69;

                    if (Game.snake.body[0].y > 19) Game.snake.body[0].y = 0;
                    else if (Game.snake.body[0].y < 0) Game.snake.body[0].y = 19;

                    if (Game.snake.AteFood())
                    {
                        Game.food.SetRandomPosition();
                    }

                    Game.CheckGameOver();
                    if (Game.Over) break;

                    Game.Draw();
                }
            }
        }

        public static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);

            Console.CursorVisible = false;
            Console.Clear();

            Game.Init();
            Console.Clear();

            DrawFrame();
            Game.wall.Draw();

            Game.Draw();
            Thread myThread = new Thread(DrawMove);
            myThread.Start();


            while (!Game.exit && !Game.Over)
            {
                while (!Game.Over)
                {
                    if (Console.KeyAvailable)
                    {
                        bool tryagain = false;
                        ConsoleKeyInfo btn;
                        if (!Game.Over) btn = Console.ReadKey(true);
                        else break;

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
                                    myThread.Abort();

                                    Console.Clear();
                                    Game.pause = true;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("GAME PAUSE");
                                    int option = 0;
                                    string[] options = { "Resume", "Save the game and exit", "Exit without saving" };

                                    while (true)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("GAME PAUSE");

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
                                                myThread = new Thread(DrawMove);
                                                myThread.Start();
                                                DrawFrame();
                                                Game.Draw();
                                                break;
                                            }

                                            else if (option == 1)
                                            {
                                                Game.Save();
                                                Game.exit = true;
                                                break;
                                            }

                                            else Game.exit = true;
                                            break;
                                        }

                                        if (key == ConsoleKey.Escape)
                                        {
                                            Console.Clear();
                                            myThread = new Thread(DrawMove);
                                            myThread.Start();
                                            DrawFrame();
                                            Game.Draw();
                                            break;
                                        }
                                    }

                                    break;
                            }
                        }
                        else Game.pause = true;

                        if (!tryagain) break;
                    }
                }

            }
        }
    }
}
