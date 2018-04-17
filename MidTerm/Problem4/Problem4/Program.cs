using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;

            List<Position> pos = new List<Position>();
            
            pos.Add(new Position(40, 0));
            Console.SetCursorPosition(40, 0);
            Console.Write(12);

            for(int i = 1; i < 12; i++)
            {
                if (i < 4) pos.Add(new Position(pos[i - 1].x + 5, pos[i - 1].y + 3));
                else if (i < 7) pos.Add(new Position(pos[i - 1].x - 5, pos[i - 1].y + 3));
                else if (i < 10) pos.Add(new Position(pos[i - 1].x - 5, pos[i - 1].y - 3));
                else pos.Add(new Position(pos[i - 1].x + 5, pos[i - 1].y - 3));

                Console.SetCursorPosition(pos[i].x, pos[i].y);
                Console.Write(i);
            }

            int time = 0;

            while (true)
            {
                int clock = time % 12;

                Console.SetCursorPosition(pos[clock].x, pos[clock].y);
                Console.ForegroundColor = ConsoleColor.Red;
                if (clock == 0) Console.Write(12);
                else Console.Write(clock);
                Console.ForegroundColor = ConsoleColor.Blue;

                time++;
                Thread.Sleep(1000);

                Console.SetCursorPosition(pos[clock].x, pos[clock].y);
                Console.ForegroundColor = ConsoleColor.Blue;
                if (clock == 0) Console.Write(12);
                else Console.Write(clock);
            }
        }
    }
}
