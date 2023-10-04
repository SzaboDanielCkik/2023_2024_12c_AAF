using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_04_LINQ_alapok
{
    class Program
    {
        static List<Jelolt> t = new List<Jelolt>();
        static void Main(string[] args)
        {
            Fajlbeolvasas();
            Feladat1();
            Feladat2();
            Feladat3();

            //HF. Valasztasok feladatait LINQ-val megoldani!

            Console.ReadLine();
        }

        private static void Feladat3()
        {
            //List<Jelolt> fuggetlenek = t.Where(c => c.part == "-").ToList();
            List<string> fuggetlenek = t.Where(c => c.part == "-").Select(x=>x.veznev+" "+x.kernev).ToList();

            //List<string> fuggetlenek = t.Select(c => c.veznev + " " + c.kernev).Where(x => x.part).ToList();
        }

        private static void Feladat1()
        {
            /*List<string> nevek = new List<string>();
            for (int i = 0; i < t.Count; i++)
                nevek.Add(t[i].veznev + " " + t[i].kernev);*/
            List<string> veznev = t.Select(adat => adat.veznev+" "+adat.kernev).ToList();
        }

        private static void Feladat2()
        {
            //List<string> partok = t.Select(c => c.part).Distinct().ToList();
            List<string> partok = t.Distinct().Select(c => c.part).ToList();
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
