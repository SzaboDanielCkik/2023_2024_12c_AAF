using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_02_09_GombGeneralas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GombokGeneralasa();
        }

        private void GombokGeneralasa()
        {
            for (int i = 0; i < 10; i++)
            {
                Button gomb = new Button();
                gomb.Width = 200;
                gomb.Text = "Gomb";
                gomb.Location = new Point(10, 10+i*53);
                gomb.Height = 50;
                gomb.Name = "GombBtn"+i;
                gomb.Click += new EventHandler(SzovegKiiratasa);
                CheckBox ch = new CheckBox();
                gomb.
                Controls.Add(gomb);
            }
        }

        void SzovegKiiratasa(object sender, EventArgs e)
        {
            Button gomb = (Button)sender;
            MessageBox.Show(gomb.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
