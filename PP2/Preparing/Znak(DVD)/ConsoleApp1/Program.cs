using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int dir = 1;
        static int x = 0, y = 0;

        static void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }
        static void Direct()
        {
            while (true)
            {
                

                if (dir == 1)
                {
                    x += 2;
                    y++;
                    if (y == Console.WindowHeight - 2)
                    {
                        dir = 2;
                    }
                    if (x == Console.WindowWidth - 2)
                    {
                        dir = 3;
                    }
                }
                if (dir == 2)
                {
                    x += 2;
                    y--;
                    if (y == 0)
                    {
                        dir = 1;
                    }
                    if (x == Console.WindowWidth - 2)
                    {
                        dir = 4;
                    }
                }
                if (dir == 3)
                {
                    x -= 2;
                    y++;
                    if (x == 0)
                    {
                        dir = 1;
                    }
                    if (y == Console.WindowHeight - 2)
                    {
                        dir = 4;
                    }
                }
                if (dir == 4)
                {
                    x -= 2;
                    y--;
                    if (x == 0)
                    {
                        dir = 2;
                    }
                    if (y == 0)
                    {
                        dir = 3;
                    }
                }

                Console.Clear();
                Draw(x, y);
                Thread.Sleep(30);
                Console.CursorVisible = false;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Thread thread = new Thread(Direct);
            thread.Start();


        }
    }
}