using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FallingBalls
{
    public partial class FallingBalls : Form
    {
        Graphics g;

        public FallingBalls()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        SolidBrush RedBrush = new SolidBrush(Color.Crimson);
        SolidBrush YellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush GreenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush BlueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush universal;
        
        Random rnd = new Random();

        List<int> x = new List<int>();
        List<int> y = new List<int>();
        List<string> colors = new List<string>();

        int prev = 0;
        string prevcol = "";
        int cnt = 0;

        private void Create_Tick(object sender, EventArgs e)
        {
            Random clr = new Random();
            int col = clr.Next(0, 4);
            switch (col)
            {
                case 0:
                    colors.Add("red");
                    break;
                case 1:
                    colors.Add("yellow");
                    break;
                case 2:
                    colors.Add("green");
                    break;
                case 3:
                    colors.Add("blue");
                    break;
                default:
                    break;
            }
            
            x.Add(rnd.Next(0, 590));
            y.Add(0);
        }

        private void Fall_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < y.Count; i++)
            {
                y[i]++;
                if (y[i] == 360)
                {
                    if (prev == i)
                    {
                        prev = -1;
                        prevcol = "";
                    }
                    x.RemoveAt(i);
                    y.RemoveAt(i);
                    colors.RemoveAt(i);
                }
            }
            Refresh();
        }

        private void FallingBalls_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < x.Count; i++)
            {
                switch (colors[i])
                {
                    case "red":
                        universal = RedBrush;
                        break;
                    case "yellow":
                        universal = YellowBrush;
                        break;
                    case "green":
                        universal = GreenBrush;
                        break;
                    case "blue":
                        universal = BlueBrush;
                        break;
                    default:
                        break;
                }
                g.FillEllipse(universal, x[i], y[i], 46, 46);
            }
        }

        private void FallingBalls_MouseDown(object sender, MouseEventArgs e)
        {
            int r = e.Location.X;
            int c = e.Location.Y;

            if (cnt == 0)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    int centerx = x[i] + 23;
                    int centery = y[i] + 23;
                    if ((r - centerx) * (r - centerx) + (c - centery) * (c - centery) <= 529)
                    {
                        prev = i;
                        prevcol = colors[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < x.Count; i++)
                {
                    int centerx = x[i] + 23;
                    int centery = y[i] + 23;
                    if ((r - centerx) * (r - centerx) + (c - centery) * (c - centery) <= 529)
                    {
                        if (colors[i] == prevcol && i != prev && prevcol != "")
                        {
                            x.RemoveAt(i);
                            y.RemoveAt(i);
                            colors.RemoveAt(i);

                            x.RemoveAt(prev);
                            y.RemoveAt(prev);
                            colors.RemoveAt(prev);
                        }
                        else
                        {
                            prev = -1;
                            prevcol = "";
                            //cnt = (cnt + 1) % 2;
                        }
                    }
                }
            }

            cnt = (cnt + 1) % 2;
        }
    }
}