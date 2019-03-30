using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pistolet
{
    class Program
    {
        public static int i = 12;
        public static void Main(string[] args)
        {
            Read("input.txt");
            Thread thread = new Thread(Bullet);
            thread.Start();            
        }

        public class Point
        {
            public int x, y;
            public Point() { }
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void Read(string path)
        {
            List<Point> body = new List<Point>();
            int y = 0;
            StreamReader sr = new StreamReader(path);
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '+')
                    {
                        body.Add(new Point(i, y));
                    }
                }
                y++;
            }
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("*");
            }
        }

        public static void Bullet()
        {
            while (i <= Console.WindowWidth-4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorVisible = false;
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("===");
                Console.SetCursorPosition(i - 1, 0);
                Console.WriteLine(" ");

                i++;
                Thread.Sleep(250);
            }
        }
    }
}
