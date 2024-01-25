using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_01_24_MySQL
{
    class Program
    {
        static Connection db = new Connection();
        static void Main(string[] args)
        {
            Console.WriteLine(db.ConnOpen());
            Console.WriteLine(db.ConnClose());

            Console.ReadLine();
        }
    }
}
