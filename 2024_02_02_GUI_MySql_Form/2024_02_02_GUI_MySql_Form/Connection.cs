using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _2024_02_02_GUI_MySql_Form
{
    class Connection
    {
        public static MySqlConnection kapcsolat = new MySqlConnection();

        static string server = "localhost"; // 127.0.0.1
        static string userId = "root";
        static string password = "";
        static string database = "centrum";

        public static MySqlConnection DataSource()
        {
            try
            {
            kapcsolat = new MySqlConnection($"server={server}; pwd={password};database={database}; uid={userId}");

            }
            catch
            {
                Console.WriteLine("Az adatbázis nem elérhető!");
            }
            return kapcsolat;
        }

        public bool ConnOpen()
        {
            DataSource();
            try
            {
                kapcsolat.Open();

            }
            catch
            {
                Console.WriteLine("Az adatbázis nem elérhető!");
            }
            return true;
        }

        public bool ConnClose()
        {
            DataSource();
            kapcsolat.Close();
            return true;
        }

        public List<string> Tablak()
        { //show tables;
            ConnOpen();
            List<string> tablak = new List<string>();
            string command = "show tables;";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tablak.Add(reader[0].ToString());
            }
            ConnClose();
            return tablak;
        }

        public List<List<string>> TablaAdatai(string tablaNev)
        {
            ConnOpen();
            List<List<string>> adatok = new List<List<string>>();
            string command = $"select * from {tablaNev};";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<string> st = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                        st.Add(reader[i].ToString());
                    adatok.Add(st);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            ConnClose();
            return adatok;
        }
        public List<string> MezoaAdatai(string tablaNev)
        {
            ConnOpen();
            List<string> adatok = new List<string>();
            string command = $"select * from {tablaNev};";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                    adatok.Add(reader.GetName(i));
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            ConnClose();
            return adatok;
        }

       
        public void Lekerdezes(string command)
        {
            ConnOpen();
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {                
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader[i] + " ");
                Console.WriteLine();
            }
            ConnClose();
        }

        public void DMLLekerdezes(string command)
        {
            ConnOpen();
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            MySqlDataReader reader = cmd.ExecuteReader();
            ConnClose();
        }

    }
}
