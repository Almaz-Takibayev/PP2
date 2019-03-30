using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static int x = 0, y = 0;
        
        static void Draw(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }
        
        
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    x++;
                    if (x == Console.WindowWidth - 1)
                    {
                        x = 0;
                    }

                }
                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    y++;

                    if (y == Console.WindowHeight - 1)
                    {
                        y = 0;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    x--;

                    if (x == 0)
                    {
                        x = Console.WindowHeight - 1;
                    }
                }
                if (consoleKeyInfo.Key == ConsoleKey.RightArrow)
                {
                    y--;

                    if (y == 0)
                    {
                        y = Console.WindowHeight - 1;
                    }
                }
                Console.Clear();
                Draw(x, y);
                Thread.Sleep(30);
                Console.CursorVisible = false;
            }
        }

        
        }
    }
    

