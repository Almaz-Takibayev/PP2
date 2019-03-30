using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Svetofor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            while (true)
            {
                Draw(ConsoleColor.Red, ConsoleColor.White, ConsoleColor.White);
                Thread.Sleep(5000);
                Draw(ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.White);
                Thread.Sleep(500);
                Draw(ConsoleColor.White, ConsoleColor.White, ConsoleColor.White);
                Thread.Sleep(250);
                Draw(ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.White);
                Thread.Sleep(500);
                Draw(ConsoleColor.White, ConsoleColor.White, ConsoleColor.White);
                Thread.Sleep(250);
                Draw(ConsoleColor.White, ConsoleColor.Yellow, ConsoleColor.White);
                Thread.Sleep(500);
                Draw(ConsoleColor.White, ConsoleColor.White, ConsoleColor.White);
                Thread.Sleep(250);
                Draw(ConsoleColor.White, ConsoleColor.White, ConsoleColor.Green);
                Thread.Sleep(5000);
            }

        }

        static void Draw(ConsoleColor c1, ConsoleColor c2, ConsoleColor c3)
        {
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<5; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = c1;
                    Console.Write('*');
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(j, i+6);
                    Console.ForegroundColor = c2;
                    Console.Write('*');
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(j, i+12);
                    Console.ForegroundColor = c3;
                    Console.Write('*');
                }
            }
        }
    }
}
