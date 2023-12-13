using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_20_Gepjarmu_Oroklodes
{
    abstract class Jarmu
    {
        protected int aktSebesseg;
        private string rendszam;

        public Jarmu(int sebesseg, string rendszam)
        {
            aktSebesseg = sebesseg;
            this.rendszam = rendszam;
        }

        public abstract bool GyorshajtottE(int sebessegKorlat);
       

        public override string ToString()
        {
            return string.Format("{0} - {1} km/h",rendszam, aktSebesseg);
        }
    }
}
