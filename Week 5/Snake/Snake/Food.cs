using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        public Point location;
        public char sign;
        public ConsoleColor color;

        public Food()
        {
            sign = '$';
            color = ConsoleColor.Green;
            SetRandomPosition();
        }

        public void Draw()
        {
            Console.SetCursorPosition(location.x + 1, location.y + 1);
            Console.ForegroundColor = color;
            Console.Write(sign);
        }

        public void SetRandomPosition()
        {
            int x, y;

            while (true)
            {
                x = new Random().Next(0, 69);
                y = new Random().Next(0, 19);

                bool generateAgain = false;
                for (int i = 0; i < Game.snake.body.Count; i++)
                {
                    if (Game.snake.body[i].x == x && Game.snake.body[i].y == y)
                    {
                        generateAgain = true;
                        break;
                    }
                }

                if (!generateAgain)
                {
                    for (int i = 0; i < Game.wall.body.Count; i++)
                    {
                        if (Game.wall.body[i].x == x && Game.wall.body[i].y == y)
                        {
                            generateAgain = true;
                            break;
                        }
                    }

                    if (!generateAgain) break;
                }
            }

            

            location = new Point(x, y);
        }
    }
}
