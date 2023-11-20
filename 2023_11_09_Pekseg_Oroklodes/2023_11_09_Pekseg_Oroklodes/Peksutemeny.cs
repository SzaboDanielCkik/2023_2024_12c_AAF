using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_09_Pekseg_Oroklodes
{
    abstract class Peksutemeny : IArlap
    {
        protected double mennyiseg;
        private double alapar;

        public Peksutemeny(double mennyiseg, double alapar)
        {
            this.mennyiseg = mennyiseg;
            this.alapar = alapar;
        }

        public abstract void Megkostol();

        public double MennyibeKerul()
        {
            return alapar * mennyiseg;
        }

        public override string ToString()
        {
            return string.Format("{0} db - {1} Ft", mennyiseg, MennyibeKerul());
        }
    }
}
