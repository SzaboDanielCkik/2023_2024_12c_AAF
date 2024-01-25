using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2024_01_18_GUIAutoszerloMuhely
{
    class Szerelo
    {
        string nev, munkakor;
        // beosztások listája: Beosztás(nap, 10 időpont); 
        // beosztások listája: Beosztás(nap); - időpontok alap true értékkel 
        public List<Beosztas> beosztas = new List<Beosztas>();
        public string Nev {get{ return nev; } }
        public string Munkakor { get { return munkakor; } set { munkakor = value; } }

        public Szerelo(string nev, string munkakor, List<Beosztas> beosztas)
        {
            this.nev = nev;
            this.munkakor = munkakor.ToLower();
            this.beosztas = beosztas;
        }

        public Szerelo(string nev, string munkakor)
        {
            this.nev = nev;
            this.munkakor = munkakor.ToLower();
            DateTime date = DateTime.Now;
            beosztas.Add(new Beosztas(string.Format("{0}.{1}.{2}",date.Year, date.Month,date.Day)));
        }

        /* Input: 
         * név;munkakör, 
         * dátum1;időpontok
         * dátum2;időpontok
           dátum3;időpontok 
           -
           Kis Pista;Olajcsere
           2024.01.13;1001010111
           2024.01.14;1100000111
           2024.01.15;1101110110 
           -
         */

        // datum, ora= [1,10]
        public bool DolgozikEEkkor(string datum, int ora)
        {
            return beosztas.Where(c => c.Datum == datum).First().idopontok[ora - 1];
        }

        public bool SzabadENaponOrakban(string datum, int kezdes, int veg)
        {
            bool joe = beosztas.Where(c => c.Datum == datum).First().FoglalhatoE(kezdes, veg);
            return joe;
        }


        public static List<Szerelo> FajlbeolvasasSzerelok(string path)
        {
            List<Szerelo> szerelok = new List<Szerelo>();
            try
            {
                StreamReader f = new StreamReader(path);
                try
                {
                    while (!f.EndOfStream)
                    {
                        string[] st = f.ReadLine().Split(';');
                        List<Beosztas> beosztasok = BeosztasokBeolvasasa(f);
                        szerelok.Add(new Szerelo(st[0], st[1], beosztasok));
                    }
                }
                catch
                {
                    Console.WriteLine("Hiba az adatok feldolgozára során!");
                }
                finally
                {
                    f.Close();
                }
            }
            catch
            {
                Console.WriteLine("Hiba: Nem elérhető a fájl! Lehet rossz az útvonal!");
            }
            return szerelok;
        }

        static List<Beosztas> BeosztasokBeolvasasa(StreamReader f)
        {
            List<Beosztas> beosztasok = new List<Beosztas>();
            string[] st;
            do
            {
                st = f.ReadLine().Split(';');
                if (st.Length > 1)
                    beosztasok.Add(new Beosztas(st[0], st[1].ToCharArray().Select(c => Convert.ToBoolean(Convert.ToInt32("" + c))).ToList()));
                else
                    break;
            } while (st.Length > 0);

            return beosztasok;
        }
    }
}
