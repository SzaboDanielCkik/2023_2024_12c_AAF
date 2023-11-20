using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_09_Pekseg_Oroklodes
{
    class Kave : IArlap
    {
        private bool habosE;
        public static double cseszekave = 180;

        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double MennyibeKerul()
        {
            if (habosE) cseszekave *= 1.5;
            return cseszekave;
        }

        public override string ToString()
        {
            return string.Format("{0} kave - {1} Ft", habosE ? "Habos" : "Nem habos", cseszekave);
        }


    }
}
