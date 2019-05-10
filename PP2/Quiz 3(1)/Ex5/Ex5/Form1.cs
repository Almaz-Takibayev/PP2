using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex5
{
    public partial class Form1 : Form
    {
        Point point1 = new Point(20, 20);
        Point point2 = new Point(450, 20);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Red, 3), point1.X, point1.Y, 50, 50);
            e.Graphics.DrawEllipse(new Pen(Color.Red, 3), point2.X, point2.Y, 50, 50);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (point1.X != point2.X)
            {
                point1.X += 10;
                point2.X -= 10;
                Refresh();
            }
            else
            {
                point1.X -= 10;
                point2.X += 10;
                Refresh();
            }
        }
    }
}
