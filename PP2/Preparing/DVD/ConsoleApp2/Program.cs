using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int dx, dy;
        public static int x, y;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            dx = dy = 1;
            x = 0;
            y = 0;
            while (true)
            {
                Move();
                Thread.Sleep(20);
            }
        }

        public static void Move()
        {
            Console.Clear();
            x += dx;
            if (x < 0)
            {
                x = 0;
                dx = 1;
            }
            else if (x > Console.WindowWidth - 3)
            {
                x = Console.WindowWidth - 4;
                dx = -1;
            }
            y += dy;
            if (y < 0)
            {
                y = 0;
                dy = 1;
            }
            else if (y > Console.WindowHeight)
            {
                y = Console.WindowHeight - 1;
                dy = -1;
            }
            Console.SetCursorPosition(x, y);
            Console.Write('*');

        }
    }
}
