using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x1, x2, wid = 50, y = 150, speed = 3;

        

        bool away = true;


        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = Width / 2 - wid;
            x2 = Width / 2;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (away)
            {
                x1 -= speed;
                x2 += speed;
                away = x1 > 0;
            }
            else
            {
                x1 += speed;
                x2 -= speed;
                away = x1 >= Width / 2 - wid-1;
            }
            Invalidate();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, x1, y, wid, wid);
            e.Graphics.FillEllipse(Brushes.Blue, x2, y, wid, wid);
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }
    }
}
