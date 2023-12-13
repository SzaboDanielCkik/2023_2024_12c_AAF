using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2023_11_28_GUI_FORM
{
    public partial class Form1 : Form
    {
        List<Konyv> konyvek = new List<Konyv>();
        List<string> szerzok = new List<string>();
        List<TextBox> szerzokButton = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fajlbeolvasas("adatok.txt");
            szerzokButton.Add(textBox2);
        }        

        private void Fajlbeolvasas(string path)
        {
            try
            {
                konyvek = Konyv.Fajlbeolvasas(path);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Nem található az adatok.txt fájl.");
            }
            catch
            {
                MessageBox.Show("Hiba a fájlbeovlasás során!");
            }
            AdatokBeolteseListboxba();
        }

        private void AdatokBeolteseListboxba()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < konyvek.Count; i++)
                listBox1.Items.Add(konyvek[i].ToString());
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Menti az adatokat bezárás után?", "Mentés", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
                Konyv.FajlbaIratas("adatok.txt",konyvek);
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Fajlbeolvasas(openFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            szerzok.Clear();
            szerzokButton.ForEach(c => szerzok.Add(c.Text));
            string sz = string.Format("{0};{1};{2};{3}",
                checkBox1.Checked, textBox1.Text, numericUpDown1.Value, string.Join(";",szerzok));
            checkBox1.Checked = false;
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            szerzokButton.ForEach(c => c.Text = "");
            konyvek.Add(new Konyv(sz));
            listBox1.Items.Add(sz);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TextBox b1 = new TextBox();
            TextBox lastButton = szerzokButton.Last();
            b1.Location = new Point(133, lastButton.Location.Y + 40);
            b1.Width = lastButton.Width;
            b1.Height = lastButton.Height;
            b1.Font = lastButton.Font;
            Controls.Add(b1);
            szerzokButton.Add(b1);
            this.Height = b1.Location.Y + b1.Height +40;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Menti az adatokat bezárás után?", "Mentés", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
                Konyv.FajlbaIratas("adatok.txt", konyvek);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult d = MessageBox.Show("Menti az adatokat bezárás után?", "Mentés", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
                Konyv.FajlbaIratas("adatok.txt", konyvek);
        }


        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
