using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex2
{
    public partial class Form1 : Form
    {
        int d = 10;
        enum Colors
        {
            red,
            blue,
            black
        }

        enum Figures
        {
            rectangle,
            ellipse,
            pie
        }
        Colors colors;
        Figures figures;
        static Color color;
        
        public Form1()
        {
            InitializeComponent();
        }
        

        void ColorChange()
        {
            Random clr = new Random();
            int col = clr.Next(0, 3);
            switch (col)
            {
                case 0:
                    color = Color.Red;
                    break;
                case 1:
                    color = Color.Blue;
                    break;
                case 2:
                    color = Color.Black;
                    break;
                default:
                    break;
            }
        }

        void FigureChange()
        {
            Random clr = new Random();
            int col = clr.Next(0, 3);
            switch (col)
            {
                case 0:
                    figures= Figures.ellipse ;
                    break;
                case 1:
                    figures = Figures.rectangle;
                    break;
                case 2:
                    figures = Figures.pie;
                    break;
                default:
                    break;
            }
        }

        

        private void Timer1_Tick(object sender, EventArgs e) 
        {
            d += 5;
            FigureChange();
            ColorChange();
            toolStripStatusLabel1.Text = string.Format("d={0}", d);
            Refresh();
        }        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (figures == Figures.ellipse)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(x + dx, y + dy, 50, 50));
            }
            else if (figures == Figures.rectangle)
            {
                e.Graphics.DrawRectangle(new Pen(color, 2), 40-d, 40-d, 50+2*d, 50+2*d);
            }
            else if (figures == Figures.pie)
            {
                e.Graphics.DrawPie(new Pen(color, 2), 40-d,40-d,50+2*d,50+2*d, 45,60);
            }
            Refresh();
        }

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }
    }
}
