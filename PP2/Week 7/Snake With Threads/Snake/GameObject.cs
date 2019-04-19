using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class GameObject
    {
        public List<Point> body = new List<Point>();
        public char sign;
        public ConsoleColor c;


        public GameObject(char sign, ConsoleColor c)
        {
            this.sign = sign;
            this.c = c;
        }

        public GameObject() { }

        public void Draw()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign.ToString() , c);
            }
        }

        public void Clear()
        {
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(' ');
            }
        }
    }
}
