using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_11_Erettsegi201305Linq
{
    class Program
    {
        static List<Jelolt> t = new List<Jelolt>();

        static void Main(string[] args)
        {
            Fajlbeolvasas();

            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadLine();
        }

        private static void Feladat7()
        {
            var eredmeny = t.GroupBy(c => c.part)
                .Select(csoport => new
                {
                    kulcs = csoport.Key,
                    ertek = csoport
                        .Where(x => x.szavazatok == csoport.Max(d => d.szavazatok))
                        .Select(n => n.veznev + " " + n.kernev).First()
                });
            foreach (var elem in eredmeny)
            {
                Console.WriteLine("{1} {0}",
                    elem.kulcs == "-" ? "független" : elem.kulcs, 
                    elem.ertek);
            }
        }

        private static void Feladat6()
        {
            int max = t.Max(c => c.szavazatok);
            t.Where(c => c.szavazatok == max).ToList()
                .ForEach(x => Console.WriteLine("{0} {1} {2}", x.veznev, x.kernev, x.part));
        }

        private static void Feladat5()
        {
            List<string> partok = t.Select(c => c.part).Distinct().ToList();
            partok.ForEach(
                c => Console.WriteLine("{0} = {1}%", 
                c == "-" ? "Független jelöltek" : c, 
                Math.Round(Szazalek(c), 2)));
        }

        static double Szazalek(string part)
        {
            double szum = t.Sum(c => c.szavazatok);
            return t.Where(c => c.part == part).Sum(x => x.szavazatok) / szum * 100;
        }

        private static void Feladat4()
        {
            double szum = t.Sum(c => c.szavazatok);
            Console.WriteLine("A választáson {0} állampolgár, a jogosultak {1}%-a vett részt.",szum, Math.Round(szum / 12345 * 100, 2));
        }



        private static void Feladat3()
        {
            //Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!
            string nev = "Alma Dalma";
            Console.WriteLine(nev);
            int egyeniSzavazat = t.Where(c => c.veznev + " " + c.kernev == nev).FirstOrDefault().szavazatok;
            if(egyeniSzavazat == 0)
                Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
            else
                Console.WriteLine("{0} szavazatot kapott.",egyeniSzavazat);
        }

        private static void Feladat2()
        {
            Console.WriteLine("Helyhatósági választáson {0} képviselőjelölt indult", t.Count);
        }

        private static void Fajlbeolvasas()
        {

            StreamReader f = new StreamReader("szavazatok.txt");
            while (!f.EndOfStream)
                t.Add(new Jelolt(f.ReadLine()));
            f.Close();
        }
    }


    class Jelolt
    {
        public int sorszam, szavazatok;
        public string veznev, kernev, part;

        public Jelolt(string sor)
        {
            string[] st = sor.Split(' ');
            sorszam = Convert.ToInt32(st[0]);
            szavazatok = Convert.ToInt32(st[1]);
            veznev = st[2];
            kernev = st[3];
            part = st[4];
        }
    }
}
