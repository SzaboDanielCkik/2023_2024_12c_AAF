using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_20_Gepjarmu_Oroklodes
{
    class AudiS8 : Jarmu
    {
        bool lezerBlokkolo;

        public AudiS8(string rendszam, int aktSebesseg, bool lezerBlokkolo) : base(aktSebesseg, rendszam)
        {
            this.lezerBlokkolo = lezerBlokkolo;
        }
        public override bool GyorshajtottE(int sebessegKorlat)
        {
            return aktSebesseg > sebessegKorlat && !lezerBlokkolo;
        }

        public override string ToString()
        {
            return "Audi:" + base.ToString();
        }
    }
}
