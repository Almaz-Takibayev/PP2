using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circlesrandom
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Color color;
        Rectangle r = new Rectangle(new Point(20, 20), new Size(20, 20));
        bool clicked = false;
        Point dot;
        int x, y;
        Random rn = new Random();
       
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            timer1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
            //g.Clear(Color.White);
            g.FillEllipse(new SolidBrush(color), r);
            x = rn.Next(1, 500);
            y = rn.Next(1, 350);
            r = new Rectangle(new Point(x, y), new Size(r.Width, r.Height));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();
            int R, G, B;
            R = rn.Next(0, 255);
            G = rn.Next(0, 255);
            B = rn.Next(0, 255);
            color = Color.FromArgb(R, G, B);
            pictureBox1.Refresh();
        }


        private void pictureBox_mousedown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                dot = e.Location;
                r = new Rectangle(new Point(e.X, e.Y),new Size(r.Width, r.Height));
                timer1.Enabled = true;
            }
         
        }
    }
}