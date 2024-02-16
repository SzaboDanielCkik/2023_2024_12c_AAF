using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _2024_02_02_GUI_MySql_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Connection db = new Connection();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(db.Tablak().ToArray());
            button2.Enabled = false;
            button1.Enabled = false;
            datagv.ClearSelection();
            datagv.ReadOnly = true;
            datagv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            datagv.AllowUserToResizeRows = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagv.RowHeadersVisible = false;
            /*string command = $"select * from {comboBox1.SelectedItem.ToString()}";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command, Connection.kapcsolat))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                datagv.DataSource = ds.Tables[0];
            }*/
            button2.Enabled = comboBox1.SelectedItem.ToString() == "kezeles" || comboBox1.SelectedItem.ToString() == "kutya";
            button1.Enabled = comboBox1.SelectedItem.ToString() == "kezeles" || comboBox1.SelectedItem.ToString() == "kutya";
            FejlecBeallitas();
            AdatokBetolteseDGV();
        }

        private void FejlecBeallitas()
        {
            List<string> st = db.MezoaAdatai(comboBox1.SelectedItem.ToString());
            datagv.ColumnCount = st.Count;
            //datagv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int i = 0; i < st.Count; i++)
            {
                datagv.Columns[i].HeaderText = st[i];
                //datagv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void AdatokBetolteseDGV()
        {
            List<List<string>> st = db.TablaAdatai(comboBox1.SelectedItem.ToString());
            datagv.RowCount = st.Count;
            for (int i = 0; i < st.Count; i++)
            {
                for (int j = 0; j < st[i].Count; j++)
                {
                    datagv.Rows[i].Cells[j].Value = st[i][j];
                }
            }
        }

        private void datagv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sorIndex = datagv.CurrentCell.RowIndex;
            for (int i = 0; i < datagv.ColumnCount; i++)
                datagv.Rows[sorIndex].Cells[i].Selected = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sorIndex = datagv.CurrentCell.RowIndex;
            string id = ""+ datagv.Rows[sorIndex].Cells[0].Value;
            db.DMLLekerdezes($"delete from {comboBox1.Text} where id = {id}");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
