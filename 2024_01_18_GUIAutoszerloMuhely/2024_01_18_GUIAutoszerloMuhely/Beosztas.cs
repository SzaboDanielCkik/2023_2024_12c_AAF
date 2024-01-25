using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_01_18_GUIAutoszerloMuhely
{
    class Beosztas
    {
        // Mezők
        string datum;
        public List<bool> idopontok = new List<bool>();
        int ev, honap, nap;

        //Getter, setter
        public string Datum { get { return datum; } }
        public int Ev { get { return ev; } }
        public int Honap { get { return honap; } }
        public int Nap { get { return nap; } }


        //Konstruktor
        public Beosztas(string datum, List<bool> idopontok)
        {
            this.datum = datum;
            this.idopontok = idopontok;
            (ev, honap, nap) = DatumSzetszed();
        }

        public Beosztas(string datum)
        {
            this.datum = datum;
            (ev, honap, nap) = DatumSzetszed();
            /*for (int i = 0; i < 10; i++)
                idopontok.Add(true);*/
            idopontok = Enumerable.Repeat(true, 10).ToList();
        }

        private (int,int,int) DatumSzetszed()
        {
            int[] szamok = Array.ConvertAll(datum.Split('.'), Convert.ToInt32);
            return (szamok[0], szamok[1], szamok[2]);
        }

        public bool FoglalhatoE(int kezdo, int veg)
        {
            int i = kezdo-1;
            while (i < veg && idopontok[i])
                i++;
            return i >= veg;
        }

        public List<(int, int)> Elfoglaltsag()
        {
            // Eltároljuk, hogy az adott napon, melyek a szabad időpontok. (kezdőÓra, óraDarab) 
            List<(int, int)> elfoglaltsag = new List<(int, int)>();

            for (int i = 0; i < idopontok.Count; i++)
            {
                if (idopontok[i])
                    elfoglaltsag.Add((i, -i + Meddig(ref i)));
            }
            return elfoglaltsag;
        }

        private int Meddig(ref int index)
        {   
            while (index < idopontok.Count && idopontok[index])
                index++;
            return index;
        }

        public override string ToString()
        {
            return string.Format(datum + " " + new string(idopontok.Select(c => c ? 'x' : '-').ToArray()));
        }
    }
}
