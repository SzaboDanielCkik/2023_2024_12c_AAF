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
            Bevezeto();

            Console.ReadLine();
        }

        static void Bevezeto()
        {
            //Console.WriteLine(db.ConnOpen());
            //Console.WriteLine(db.ConnClose());

            db.Tablak();
            /*string tablaNev;
            do
            {
                Console.Write("Válasszon egy táblát és írja be a tábla nevét: ");
                tablaNev = Console.ReadLine();
            } while (!db.TablaAdatai(tablaNev));*/
        }
    }
}
