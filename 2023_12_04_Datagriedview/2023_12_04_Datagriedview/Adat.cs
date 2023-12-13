using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_04_Datagriedview
{
    class Adat
    {
        public string nyelv;
        public List<int> vizsgazokSzama = new List<int>();

        public Adat(string sor)
        {
            string[] st = sor.Split(';');
            nyelv = st[0];
            for (int i = 1; i < st.Length; i++)
                vizsgazokSzama.Add(Convert.ToInt32(st[i]));
        }
    }
}
