using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_12_Kosarlabda
{
    class Program
    {
        static List<meccs> meccsek = new List<meccs>();
        static void Main(string[] args)
        {
            FajlBeolvasas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

            Console.ReadLine();
        }

        private static void Feladat7()
        {
            Console.WriteLine("7. feladat:");
            meccsek.GroupBy(c => c.helyszin)
                .Select(cs => new {
                    kulcs = cs.Key,
                    ertek = cs.Count()
                }).Where(x => x.ertek > 20).ToList()
                .ForEach(d => Console.WriteLine("\t{0}: {1}",d.kulcs, d.ertek));
        }

        private static void Feladat6()
        {
            Console.WriteLine("6. feladat:");
            meccsek.Where(c => c.idopont == "2004-11-21").ToList()
                .ForEach(x=>Console.WriteLine("\t{0} - {1} ({2}:{3})",
                x.hazai,x.idegen,x.hazai_pont,x.idegen_pont));
        }

        private static void Feladat5()
        {
            Console.Write("5. feladat: barcelonai csapat neve: ");
            Console.WriteLine(meccsek.Where(c=>c.hazai.Contains("Barcelona")).First().hazai);
        }

        private static void Feladat4()
        {
            Console.Write("3. feladat: Volt döntetlen? ");
            Console.WriteLine(
                meccsek.Where(c=>c.hazai_pont == c.idegen_pont).Count()==0 ?"nem":"igen");

        }

        private static void Feladat3()
        {
            
            Console.WriteLine("Real Madrid: Hazai: {0}, Idegen: {1}",
                meccsek.Where(c=>c.hazai.Contains("Real Madrid")).Count(),
                meccsek.Where(c=>c.idegen.Contains("Real Madrid")).Count());
        }

        private static void FajlBeolvasas()
        {
            StreamReader r = new StreamReader("eredmenyek.csv");
            r.ReadLine();
            while (!r.EndOfStream)
                meccsek.Add(new meccs(r.ReadLine()));
            r.Close();
        }
    }

    class meccs
    {
        public string hazai, idegen,helyszin,idopont;
        public int hazai_pont, idegen_pont;

        public meccs(string sor)
        {
            string[] sp = sor.Split(';');
            hazai = sp[0];
            idegen = sp[1];
            hazai_pont = Convert.ToInt32(sp[2]);
            idegen_pont = Convert.ToInt32(sp[3]);
            helyszin = sp[4];
            idopont = sp[5];
        }
    }

}
