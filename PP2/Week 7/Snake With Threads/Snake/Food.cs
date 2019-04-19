using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : GameObject
    {
        public Food(char sign, List<Point> worm, List<Point> wall, ConsoleColor c) : base(sign, c)
        {
            GenerateLocation(worm, wall);
        }
        public Food(char sign, ConsoleColor c) : base(sign, c)
        {
            GenerateLocation();
        }

        public Food() : base() { }

        public void GenerateLocation()
        {
            Point p = new Point(10, 35);
            body.Add(p);
        }

        public void GenerateLocation(List<Point> wormBody, List<Point> wallBody)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);

            Point p = new Point(random.Next(1, 40), random.Next(1, 40));

            while (!IsGoodPoint(p, wormBody) || !IsGoodPoint(p, wallBody))
            {
                p = new Point(random.Next(1, 40), random.Next(1, 40));
            }
            body.Add(p);
        }

        bool IsGoodPoint(Point p, List<Point> points)
        {
            bool res = true;

            foreach (Point t in points)
            {
                if (p.X == t.X && p.Y == t.Y)
                {
                    res = false;
                    break;
                }
            }

            return res;
        }
    }
}