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
                Console.WriteLine(reader[0]);
            }
            ConnClose();
        }

        public bool TablaAdatai(string tablaNev)
        {
            bool good = false;
            ConnOpen();
            string command = $"select * from {tablaNev};";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i] + " ");
                    Console.WriteLine();
                }
                good = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            ConnClose();
            return good;
        }

        public void TablaAdatai()
        {
            ConnOpen();
            string command = $"select * from gazda;";
            MySqlCommand cmd = new MySqlCommand(command, kapcsolat);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine(reader.GetInt32(0)+" "+reader.GetString(1)+" "+reader.GetInt32(2));
                //Console.WriteLine(reader["id"]+" "+reader["nev"]+" "+reader["kerulet"]);
                //Console.WriteLine(reader[0]+" "+reader[1]+" "+reader[2]);
                for (int i = 0; i < reader.FieldCount; i++)
                    Console.Write(reader[i] + " ");
                Console.WriteLine();
            }
            ConnClose();
        }

    }
}
