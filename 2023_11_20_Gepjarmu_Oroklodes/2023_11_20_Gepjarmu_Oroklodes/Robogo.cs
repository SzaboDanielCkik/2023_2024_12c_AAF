using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_20_Gepjarmu_Oroklodes
{
    class Robogo : Jarmu, IKisGepjarmu
    {
        int maxSebesseg;

        public Robogo(string rendszam, int aktSebesseg, int maxSebesseg) : base(aktSebesseg,rendszam)
        {
            this.maxSebesseg = maxSebesseg;
        }

        public bool HaladhatItt(int sebesseg)
        {
            return maxSebesseg <= sebesseg;
        }

        public override bool GyorshajtottE(int sebessegKorlat)
        {
            return aktSebesseg > sebessegKorlat;
        }

        public override string ToString()
        {
            return string.Format("Robogo: " + base.ToString());
        }
    }
}
