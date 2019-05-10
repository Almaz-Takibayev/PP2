using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        int x, y;
        Color color;

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
        Figures figures;
        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random clr = new Random();
            int col = clr.Next(0, 3);
            ColorChange( col);
            if (figures == Figures.ellipse)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(x , y , 70, 70));
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(x-10, y-10, 90, 90));
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(x-20, y-20, 110, 110));
                col = clr.Next(0, 3);
                ColorChange(col);
            }
            else if (figures == Figures.rectangle)
            {
                e.Graphics.DrawRectangle(new Pen(color, 2), new Rectangle(x, y , 70, 70));
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawRectangle(new Pen(color, 2), new Rectangle(x- 10, y - 10, 90, 90));
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawRectangle(new Pen(color, 2), new Rectangle(x - 20, y - 20, 110, 110));
                col = clr.Next(0, 3);
                ColorChange(col);
            }
            else if (figures == Figures.pie)
            {
                e.Graphics.DrawPie(new Pen(color, 2),new Rectangle ( x , y , 70 , 70), 45, 90);
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawPie(new Pen(color, 2), new Rectangle(x - 10, y - 10, 90, 90), 45, 90);
                col = clr.Next(0, 3);
                ColorChange(col);
                e.Graphics.DrawPie(new Pen(color, 2), new Rectangle(x - 20, y - 20, 110, 110), 45, 90);
                col = clr.Next(0, 3);
                ColorChange(col);
            }
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Random clr = new Random();
                int col = clr.Next(0, 3);
                FigureChange(col);
                ColorChange(col);
                x = e.Location.X;
                y = e.Location.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {            
                timer1.Tick += Timer1_Tick;           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        void ColorChange(int col)
        {
            
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

        void FigureChange(int col)
        {
            switch (col)
            {
                case 0:
                    figures = Figures.ellipse;
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
    }
}
