using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake;

namespace SnakeBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Init();
            Snake.Snake snake = Game.snake;
            while (true)
            {
                if (Game.food.location.x < Game.snake.body[0].x) Game.snake.direction = 1;
                Game.snake.Move(Game.snake.direction);
            }
        }
    }
}
