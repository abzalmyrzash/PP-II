using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleSnake
{
    class Program
    {
        static void DrawFrame()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 0; i < 72; i++)
            {
                Console.Write('*');
            }

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine();
                Console.Write('*');
                Console.SetCursorPosition(71, i + 1);
                Console.Write('*');
            }

            Console.WriteLine();

            for (int i = 0; i < 72; i++)
            {
                Console.Write('*');
            }
        }

        static void DrawMoveFunction()
        {
            while (!Game.Over)
            {
                Game.Draw();

                Thread.Sleep(200);

                Game.snake.Move();

                if (Game.snake.body[0].x < 0) Game.snake.body[0].x = 69;
                if (Game.snake.body[0].x > 69) Game.snake.body[0].x = 0;
                if (Game.snake.body[0].y < 0) Game.snake.body[0].y = 69;
                if (Game.snake.body[0].y > 69) Game.snake.body[0].y = 0;

                Game.CheckGameOver();
                if (Game.snake.AteFood()) Game.food.SetRandomPosition();
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game.Init();
            Console.Clear();
            DrawFrame();

            Thread mythread = new Thread(DrawMoveFunction);
            mythread.Start();

            while (!Game.Over)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W: Game.snake.direction = 1;
                        break;
                    case ConsoleKey.S: Game.snake.direction = 2;
                        break;
                    case ConsoleKey.A: Game.snake.direction = 3;
                        break;
                    case ConsoleKey.D: Game.snake.direction = 4;
                        break;
                }
            }
        }
    }
}
