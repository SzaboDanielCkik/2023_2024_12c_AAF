using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_28_GUI_FORM
{
    class Konyv
    {
        public string szerzo, cim;
        public int evszam;
        public bool felujitando, tobbszerzo;
        public List<string> szerzok = new List<string>();

        public Konyv(string sor)
        {
            string[] st = sor.Split(';');
            felujitando = Convert.ToBoolean(st[0]);
            cim = st[1];
            evszam = Convert.ToInt32(st[2]);
            tobbszerzo = st.Length > 4;
            if (tobbszerzo)
                for (int i = 3; i < st.Length; i++)
                    szerzok.Add(st[i]);
            else
                szerzo = st[3];
        }

        public static List<Konyv> Fajlbeolvasas(string path)
        {
            List<Konyv> konyvek = new List<Konyv>();
            StreamReader f = new StreamReader(path);
            while (!f.EndOfStream)
                konyvek.Add(new Konyv(f.ReadLine()));
            f.Close();
            return konyvek;
        }

        public static void FajlbaIratas(string path, List<Konyv> t)
        {
            StreamWriter f = new StreamWriter(path);
            t.ForEach(c => f.WriteLine(c.ToString()));
            f.Close();
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3}", felujitando, cim, evszam,
                !tobbszerzo ? szerzo : string.Join(";", szerzok));
        }
    }
}
