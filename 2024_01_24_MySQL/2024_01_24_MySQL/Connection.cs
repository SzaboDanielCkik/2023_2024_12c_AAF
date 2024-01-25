using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _2024_01_24_MySQL
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
            kapcsolat = new MySqlConnection($"server={server}; pwd={password};database={database}; uid={userId}");
            return kapcsolat;
        }

        public bool ConnOpen()
        {
            DataSource();
            kapcsolat.Open();
            return true;
        }

        public bool ConnClose()
        {
            DataSource();
            kapcsolat.Close();
            return true;
        }

        public void Tablak()
        { //show tables;
            ConnOpen();
            string command = "show tables;";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine();
            }
        }

    }
}
