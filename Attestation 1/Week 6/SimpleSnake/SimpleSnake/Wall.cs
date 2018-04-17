using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake
{
    [Serializable]
    public class Wall
    {
        public List<Point> body;
        char sign;
        ConsoleColor color;

        public Wall()
        {
            body = new List<Point>();
            sign = '#';
            color = ConsoleColor.White;

            StreamReader sr = new StreamReader(@"C:\users\abzal\desktop\PPIILabs\week 5\Snake\Snake\bin\debug\Levels\Level1.txt");
            for (int i = 0; i < 20; i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '#') body.Add(new Point(j, i));
                }
            }

            sr.Close();
        }

        public void Draw()
        {
            Console.ForegroundColor = color;

            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x + 1, p.y + 1);
                Console.Write(sign);
            }
        }
    }
}