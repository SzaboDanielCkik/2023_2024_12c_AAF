using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_16_Nyelvvizsga
{
    class Program
    {
        static List<Vizsga> sikeres = Vizsga.Fajlbeolvasas("sikeres.csv");
        static List<Vizsga> sikertelen = Vizsga.Fajlbeolvasas("sikertelen.csv");
        static int ev;

        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat4();

            Console.ReadLine();
        }

        private static void Feladat4()
        {
            Console.WriteLine("4. feladat: ");
            (string nyelv, double arany) = LegsikertelenebbNyelv(ev);
            Console.WriteLine("{0}-ben {1} nyelvből a sikertelen vizsgák aránya {2}%",
                ev,nyelv/*,arany*/);
        }

        private static Vizsga LegsikertelenebbNyelv(int ev)
        {
            return sikertelen
                 .Select(c =>(double)c.jelentkezesek[ev - 2009] / (c.jelentkezesek[ev - 2009] +
                    sikeres
                        .Where(x => x.nyelv == c.nyelv)
                        .First()
                        .jelentkezesek[ev - 2009])
                 )
        }

        private static void Feladat3()
        {
            Console.WriteLine("3. feladat: ");
            try
            {
                do
                {
                    Console.Write("\tVizsgálnadó év: ");
                    ev = Convert.ToInt32(Console.ReadLine());
                } while (ev < 2009 || ev > 2017);
            }
            catch {
                Console.WriteLine("Nem szám lett megadva! Enter lenyomása után folytathatja!");
                Feladat3();
            }
        }

        private static void Feladat2()
        {
            Console.WriteLine("2. feladat: A legnépszerűbb nyelvek: ");
            List<Vizsga> sv = sikeres
                 .OrderByDescending(c => c.jelentkezesek.Sum() +
                    sikertelen
                        .Where(x => x.nyelv == c.nyelv)
                        .First()
                        .jelentkezesek.Sum()
                 ).ToList();
            for (int i = 0; i < 3; i++)
                Console.WriteLine("\t"+sv[i].nyelv);
        }


    }
}
