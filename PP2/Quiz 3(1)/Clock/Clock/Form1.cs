using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        double a = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 3.55;
            Refresh();
            progressBar1.PerformStep();            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Green);            
            e.Graphics.FillPie(solidBrush, new Rectangle(250, 20, 300, 300), 0, float.Parse(a.ToString()));
        }
    }
}
