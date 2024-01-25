using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2024_01_18_GUIAutoszerloMuhely
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MunkaTabla munkaTabla = new MunkaTabla("szerelok.txt");

        private void Form1_Load(object sender, EventArgs e)
        {
            TablaBeallitasok(munkaTabla.szerelok.Count);
            TablaAdatokMegjelenitese();
        }

        private void TablaAdatokMegjelenitese()
        {
            RowHeaderAdatBeallitas(munkaTabla.szerelok);
            ComboBoxMunkakorBeallitas();
            ComboBoxDatumBeallitas();
            TablaNapBetoltes(0);
        }

        private void ComboBoxMunkakorBeallitas()
        {
            //comboBox2.TextChanged 
            comboBox2.Items.Add("Mindenki");
            List<string> munkakorok = munkaTabla.szerelok.Select(c => c.Munkakor).Distinct().ToList();
            for (int i = 0; i < munkakorok.Count; i++)
                comboBox2.Items.Add(munkakorok[i]);
            comboBox2.Text = "--- Válassz ---";
        }

        private void TablaNapBetoltes(int napIndex)
        {
            RowHeaderAdatBeallitas(munkaTabla.szerelok);
            dataGV.RowCount = munkaTabla.szerelok.Count;
            TablaBeallitasok(dataGV.RowCount);
            for (int i = 0; i < munkaTabla.szerelok.Count; i++)
            {
                var szures = munkaTabla.szerelok[i].beosztas.Where(c => c.Datum == comboBox1.Items[napIndex].ToString());
                if (szures.Count() > 0)
                {
                    List<bool> idopontok = szures.First().idopontok;
                    TablaSorBeszinez(idopontok, i);
                }
                else
                    TablaSorBeszinez(null, i);
            }
        }

        private void TablaSorBeszinez(List<bool> idopontok, int sor)
        { 
            if(idopontok != null)
                for (int j = 0; j < idopontok.Count; j++)
                    dataGV.Rows[sor].Cells[j].Style.BackColor = idopontok[j] ? Color.Green : Color.Red;
            else
                for (int j = 0; j < munkaTabla.szerelok[sor].beosztas[0].idopontok.Count; j++)

                    dataGV.Rows[sor].Cells[j].Style.BackColor = Color.Gray;
        }

        private void ComboBoxDatumBeallitas()
        {
            List<string> datumok = string.Join(";", munkaTabla.szerelok.Select(c => string.Join(";", c.beosztas.Select(d => d.Datum)))).Split(';').Distinct().ToList();
            for (int i = 0; i < datumok.Count; i++)
                comboBox1.Items.Add(datumok[i]);
            comboBox1.Text = datumok[0];
            comboBox2.Text = comboBox2.Items[0].ToString();
        }

        private void RowHeaderAdatBeallitas(List<Szerelo> aktSzerelok)
        {
            dataGV.RowCount = aktSzerelok.Count;
            TablaBeallitasok(dataGV.RowCount);
            for (int i = 0; i < aktSzerelok.Count; i++)
            {
                dataGV.Rows[i].HeaderCell.Value = string.Format("{0} ({1})", aktSzerelok[i].Nev, aktSzerelok[i].Munkakor);
            }
        }

        private void TablaBeallitasok(int sorszam)
        {
            dataGV.Width = 652;
            dataGV.RowCount = sorszam;
            dataGV.ColumnCount = 10;
            for (int i = 0; i < dataGV.ColumnCount; i++)
            {
                dataGV.Columns[i].HeaderText = "" + (i + 1);
                dataGV.Columns[i].Width = 50;
            }
            for (int i = 0; i < dataGV.RowCount; i++)
            {
                dataGV.Rows[i].Height = 50;
                dataGV.RowHeadersWidth = 150;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGV.ClearSelection();
            TablaNapBetoltes(comboBox1.SelectedIndex);
            comboBox2.Text = comboBox2.Items[0].ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGV.ClearSelection();
            int aktDatumIndex = comboBox1.SelectedIndex;
            string munkakor = comboBox2.SelectedItem.ToString();
            if (comboBox2.SelectedIndex != 0)
            {
                List<Szerelo> munkakorok = munkaTabla.MunkakorKeres(munkakor).Where(c=>c.beosztas.Where(d=>d.Datum == comboBox1.Items[aktDatumIndex].ToString()).Count() > 0).ToList();
                if (munkakorok.Count() > 0)
                {
                    dataGV.RowCount = munkakorok.Count;
                    RowHeaderAdatBeallitas(munkakorok);
                    for (int i = 0; i < munkakorok.Count; i++)
                    {
                        TablaSorBeszinez(munkakorok[i].beosztas.First().idopontok, i);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Ezen a napon nem dolgozik a(z) {0} kolléga", munkakor));
                    dataGV.RowCount = 1;
                }
                    
            }
            else
            {
                TablaNapBetoltes(aktDatumIndex);
            }
        }
    }
}
