using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E1
{
    public partial class Form1 : Form
    {
        int dx = 5, dy = 5, x = 100, y = 100, r = 20;
        Pen pen = new Pen(Color.Red);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
            if (y + 2 * r >= this.Height-3 || y <= 1)
                dy = -dy;
            if (x + 2 * r >= this.Width-3 || x <= 1)
                dx = -dx;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += dx;
            y += dy;
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }        
    }
}
