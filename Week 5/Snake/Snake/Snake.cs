using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public List<Point> body;
        Point last;

        public string username;
        public int score, highscore;

        char sign;
        ConsoleColor color;

        public Snake(string _username)
        {
            username = _username;
            score = 0;
            string path = @"C:\Snake Game\usernames\" + username + "\\highscore.txt";

            StreamReader sr = new StreamReader(path);
            highscore = int.Parse(sr.ReadLine());
            sr.Close();

            body = new List<Point>();
            sign = 'o';
            color = ConsoleColor.Yellow;

            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
        }

        public void Move(int dx, int dy)
        {
            last = body.Last();
            Console.SetCursorPosition(last.x + 1, last.y + 1);
            Console.Write(' ');

            for(int i = body.Count - 1; i > 0; i--)
                body[i] = body[i - 1];

            body[0] = new Point(body[0].x + dx, body[0].y + dy);
        }

        public void Draw()
        {
            for(int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].x + 1, body[i].y + 1);
                Console.ForegroundColor = color;
                if (i == 0) Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sign);
            }
        }

        public bool AteFood()
        {
            if (body[0].x == Game.food.location.x && body[0].y == Game.food.location.y)
            {
                body.Add(last);
                score += 10;
                return true;
            }
            return false;
        }

        public bool CollisionWithItself()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }

            return false;
        }

        public bool CollisionWithWall()
        {
            for(int i = 0; i < Game.wall.body.Count; i++)
            {
                if (body[0].x == Game.wall.body[i].x && body[0].y == Game.wall.body[i].y)
                    return true;
            }

            return false;
        }
    }
}
