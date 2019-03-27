using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        int x;
        int y;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter1(value);
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter2(value);
            }
        }

        int Filter1(int v)
        {
            if (v < 0)
            {
                v = 39;
            }else if (v > 39)
            {
                v = 0;
            }
            return v;
        }

        int Filter2(int v)
        {
            if (v < 1)
            {
                v = 40;
            }
            else if (v > 40)
            {
                v = 1;
            }
            return v;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
