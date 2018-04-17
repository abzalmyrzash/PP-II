using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake{
    [Serializable]
    public class Snake
    {
        public List<Point> body;
        Point last;
        public int speed;

        public string username;
        public int direction, score, highscore;

        char sign = 'o';
        ConsoleColor color = ConsoleColor.Yellow;

        public Snake(string _username)
        {
            username = _username;
            score = 0;
            speed = 150;
            direction = 4;
            string path = @"C:\Snake Game\usernames\" + username + "\\highscores.txt";

            StreamReader sr = new StreamReader(path);
            highscore = int.Parse(sr.ReadLine().Remove(0, 4));
            sr.Close();

            body = new List<Point>();

            body.Add(new Point(12, 10));
            body.Add(new Point(11, 10));
            body.Add(new Point(10, 10));
        }

        public Snake()
        {

        }

        public void Move(int dir)
        {
            if (dir != 0)
            {
                int dx = 0, dy = 0;

                last = body.Last();

                for (int i = body.Count - 1; i > 0; i--)
                    body[i] = body[i - 1];

                switch (dir)
                {
                    case 1:
                        dx = 0; dy = -1;
                        break;
                    case 2:
                        dx = 0; dy = 1;
                        break;
                    case 3:
                        dx = -1; dy = 0;
                        break;
                    case 4:
                        dx = 1; dy = 0;
                        break;
                }

                body[0] = new Point(body[0].x + dx, body[0].y + dy);
            }
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
            if (last != null)
            {
                Console.SetCursorPosition(last.x + 1, last.y + 1);
                Console.Write(' ');
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
