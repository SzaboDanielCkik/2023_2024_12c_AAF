using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_11_Objektumok
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutya k1 = new Kutya("Bütyök","barna", true);
            Console.WriteLine(k1.ToString());

            Console.ReadLine();
        }

    }

    class Kutya
    {
        // Jellemzői, adattagjai, mezői, tulajdonságai
        string nev, szin, fajta;
        int kor;
        bool kan;

        // Konstruktor (speciális metódus) - példányosításhoz
        // public Kutya() { }

        public Kutya(string nev, string szin, bool kan)
        {
            this.nev = nev;
            this.szin = szin;
            this.kan = kan;
        }

        // Metódusok - eljárások, függvények - feladatok
        public void Ugatas()
        {
            Console.WriteLine("Vau-Vau");
        }

        // Getter, setter
        public string GetNev() { return nev; }
        public void SetNev(string ujnev) { nev = ujnev; }

        public string Nev
        {
            get { return nev; }
            private set { nev = value; }
        }


        static List<string> kartevok = new List<string>() { "bolha", "tetű" };

        public string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", nev, szin, fajta, kor, kan);
        }

    }
}
