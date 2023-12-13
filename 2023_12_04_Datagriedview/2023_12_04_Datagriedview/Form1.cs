using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023_12_04_Datagriedview
{

    public partial class Form1 : Form
    {
        List<Adat> t = new List<Adat>();
        string[] oszlopFejlec;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fajlbeolvasas("sikeres.csv");
            TablaFeltoltes();
            TablaBeallitas();


            /*tabla.RowCount = 6;
            tabla.ColumnCount = 4;
            tabla.Rows[0].Cells[2].Value = "Bambi";
            tabla.Rows[0].HeaderCell.Value = "12";
            tabla.Columns[0].HeaderCell.Value = "13";
            tabla.Rows[0].Height = 60;*/
        }

        private void TablaBeallitas()
        {
            
        }

        void TablaFeltoltes()
        {
            tabla.RowCount = t.Count;
            tabla.ColumnCount = oszlopFejlec.Length;
            tabla.RowHeadersVisible = false;
            FejlecBetoltese();
            AdatokBetoltese();
        }

        void AdatokBetoltese()
        {
            for (int i = 0; i < t.Count; i++)
            {
                tabla.Rows[i].Cells[0].Value = t[i].nyelv;
                for (int j = 0; j < t[i].vizsgazokSzama.Count; j++)
                {
                    tabla.Rows[i].Cells[j+1].Value = t[i].vizsgazokSzama[j];
                }
            }
        }

        void FejlecBetoltese()
        {
            for (int i = 0; i < oszlopFejlec.Length; i++)
                tabla.Columns[i].HeaderCell.Value = oszlopFejlec[i];
        }

        private void Fajlbeolvasas(string path)
        {
            StreamReader f = new StreamReader(path);
            oszlopFejlec = f.ReadLine().Split(';');
            while (!f.EndOfStream)
                t.Add(new Adat(f.ReadLine()));
            f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
