using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023_12_05_GUI_kooridnatageometria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* HF - kitöltött háromszög*/

        private void button1_Click(object sender, EventArgs e)
        {
            PontRajzolasa(10, 10);
        }
        void PontRajzolasa(int a, int b)
        {
            //Point pont = new Point(a, b);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Bitmap pixel = new Bitmap(2,2);
            pixel.SetPixel(1,1, Color.Black);
            g.DrawImage(pixel, a, b);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLine(new Pen(Color.Red), 50, 10, 300, 10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //g.DrawEllipse(new Pen(Color.Green), 80, 30, 100, 100);
            g.FillEllipse(Brushes.Green, 80, 30, 100, 100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawRectangle(new Pen(Color.Blue), 200, 30, 80, 150);

        }
    }
}
