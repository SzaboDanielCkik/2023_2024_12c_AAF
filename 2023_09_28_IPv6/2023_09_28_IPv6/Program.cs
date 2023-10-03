using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_28_IPv6
{
    class Program
    {
        static List<Adat> t = new List<Adat>();
        static void Main(string[] args)
        {
            Beolvasas();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Console.ReadLine();
        }

        private static void Feladat2()
        {
            Console.WriteLine("2. feladat:");
            Console.WriteLine("Az állományban {0} darab adatsor van.",t.Count);
            Console.WriteLine();
        }
        private static void Feladat3()
        {
            Console.WriteLine("3. feladat:");
            Console.WriteLine("A legalacsonyabb tárolt IP-cím:\n{0}", t[MinIndex()].sor);
            Console.WriteLine();
        }

        private static int MinIndex()
        {
            int mini = 0;

            for (int i = 1; i < t.Count; i++)
            {
                string akt = t[mini].sor;
                int j = 0;
                while (j < t[i].sor.Length && t[i].sor[j] == akt[j])
                    j++;
                if (t[i].sor[j] < akt[j])
                    mini = i;
            }
            return mini;
        }

        private static void Feladat4()
        {
            Console.WriteLine("4. feladat:");
            Console.WriteLine("Dokumentációs cím: {0} darab",DarabSzamol("2001:0db8"));
            Console.WriteLine("Globális egyedi cím: {0} darab", DarabSzamol("2001:0e"));
            Console.WriteLine("Helyi egyedi cím: {0} darab", DarabSzamol("fc")+DarabSzamol("fd"));
            Console.WriteLine();
        }

        static int DarabSzamol(string sz)
        {
            int db = 0;
            for (int i = 0; i < t.Count; i++)
                if (t[i].sor.Substring(0, sz.Length) == sz) db++;
            return db;
        }
        private static void Feladat5()
        {
            StreamWriter g = new StreamWriter("sok.txt");
            for (int i = 0; i < t.Count; i++)
            {
                if (t[i].NullaDb() >= 18)
                    g.WriteLine("{0} {1}",i,t[i].sor);
            }
            g.Close();
        }
        private static void Feladat6()
        {
            Console.WriteLine("6. feladat:");
            Console.Write("Kérek egy sorszámot: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;
            string sor = t[index].sor;
            Console.WriteLine(sor);
            Console.WriteLine(t[index].Rovidites());
            Console.WriteLine();
        }

        
        private static void Feladat7()
        {
            Console.WriteLine("7. feladat:");

            Console.WriteLine();
        }

        private static void Beolvasas()
        {
            StreamReader f = new StreamReader("ip.txt");
            while (!f.EndOfStream)
                t.Add(new Adat(f.ReadLine()));
            f.Close();
        }
    }

    class Adat
    {
        public string sor;
        public List<string> st = new List<string>();
        public List<string> str = new List<string>();
        public Adat(string line)
        {
            sor = line;
            st = line.Split(':').ToList();
        }

        public int NullaDb()
        {
            int db = 0;
            for (int i = 0; i < sor.Length; i++)
                db += sor[i] == '0' ? 1 : 0;
            return db;
        }
        public string Rovidites()
        {
            string rovid = "";
            for (int i = 0; i < st.Count; i++)
            {
                string sv;
                if (st[i] == "0000")
                    sv= "0";
                else if (st[i][0] == '0')
                    sv= st[i].Substring(1, 3);
                else if (st[i].Substring(0, 2) == "00")
                    sv= st[i].Substring(2, 2);
                else if (st[i].Substring(0, 3) == "000")
                    sv= st[i].Substring(3, 1);
                else
                    sv= st[i];
                str.Add(sv);
                rovid += sv + (i < st.Count - 1 ? ":" : "");
            }
            return rovid;
        }

        public string Legrovidebb()
        {
            return "";
        }
    }
}
