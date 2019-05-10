using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ballon
{
    public partial class Form1 : Form
    {
        int x, y, dy=1;
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            timer1.Tick -= timer1_Tick;
        }

        //private void Form1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    x = e.Location.X;
        //    y = e.Location.Y;
        //    timer1.Tick += timer1_Tick;
        //    timer1.Start();

        //}

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Blue);
            if (x != 0)
            {


                e.Graphics.FillEllipse(solidBrush, x, y, 50, 50);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            y += dy;
            Refresh();
        }
    }
}
