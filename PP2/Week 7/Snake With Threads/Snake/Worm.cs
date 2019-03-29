using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm:GameObject
    {
        public enum Direction
        {
            Stop,
            Up,
            Down,
            Left,
            Right
        };

        public int Dx
        {
            get;
            set;
        }

        public int Dy
        {
            get;
            set;
        }

        public Worm() : base() { }

        public Direction dir;
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point(20, 20));
            dir = Direction.Stop;
            Dx = Dy = 0;
        }

        public void Move()
        {
            Clear();
            for(int i=body.Count-1; i>0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0].X += Dx;
            body[0].Y += Dy;
        }

        public bool IsIntersected(List<Point> points)
        {
            bool res = false;

            foreach(Point p in points)
            {
                if (p == body[0])
                {
                    continue;
                }
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public void Eat(List<Point> body)
        {
            this.body.Add(new Point(body[0].X, body[0].Y));
        }
    }
}
