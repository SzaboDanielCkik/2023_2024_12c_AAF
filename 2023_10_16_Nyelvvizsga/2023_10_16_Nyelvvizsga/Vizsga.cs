using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_16_Nyelvvizsga
{
    class Vizsga
    {
        public string nyelv;
        public List<int> jelentkezesek = new List<int>();

        public Vizsga(string sor)
        {
            string[] st = sor.Split(';');
            nyelv = st[0];
            for (int i = 1; i < st.Length; i++)
                jelentkezesek.Add(Convert.ToInt32(st[i]));
        }
        public static List<Vizsga> Fajlbeolvasas(string hely)
        {
            List<Vizsga> t = new List<Vizsga>();
            StreamReader f = new StreamReader(hely);
            f.ReadLine();
            while (!f.EndOfStream)
                t.Add(new Vizsga(f.ReadLine()));
            f.Close();
            return t;
        }

        public override string ToString()
        {
            string adatok = nyelv+" ";
            jelentkezesek.ForEach(c => adatok += c + " ");
            return adatok;
        }
    }
}
