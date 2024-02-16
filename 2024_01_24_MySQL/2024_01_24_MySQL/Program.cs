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
            //Feladat3();
            //Feladat4();
            //Feladat5();
            //Feladat6();
            Feladat7();

            Console.ReadLine();
        }

        private static void Feladat7()
        {
            string command = "Select g.nev, count(ke.id) as alkalom, sum(ke.dij) as összesen " +
                             "From gazda g inner join kutya k on g.id = k.gazdaid inner join  kezeles ke on k.id = ke.kutyaid " +
                             "Where g.nev like '%Medgyessy%' " +
                             "Group by g.nev;";
            db.Lekerdezes(command);
        }

        private static void Feladat6()
        {
            string command = "Select kezelestipus.jelleg, kezeles.kezdet, kezeles.veg, kezeles.dij " +
                             "From kezelestipus inner join kezeles on kezelestipus.id = kezeles.kezelestipusid " +
                             "Where kezelestipus.jelleg like '%gyógy%' and kezeles.veg between '2017-10-01' and '2017-12-31';";
            db.Lekerdezes(command);
        }

        private static void Feladat5()
        {
            string command = "Select kezelestipus.jelleg, count(kezeles.id) " +
                             "From kezelestipus, kezeles " +
                             "Where kezelestipus.id = kezeles.kezelestipusid " +
                             "Group by kezelestipus.jelleg;";
            db.Lekerdezes(command);
        }

        private static void Feladat4()
        {
            string command = "Select kerulet, nev " +
                             "From gazda " +
                             "Where kerulet = 17 or kerulet = 18 " +
                             "Order by kerulet, nev;";
            db.Lekerdezes(command);
        }

        private static void Feladat3()
        {
            string command = "Select id, kezdet, veg, dij " +
                             "From kezeles";
            db.Lekerdezes(command);
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
