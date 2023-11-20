using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_09_Pekseg_Oroklodes
{
    class Pogacsa : Peksutemeny
    {

        public Pogacsa(double mennyiseg, double alapar) : base(mennyiseg, alapar)
        { 
        }

        public override void Megkostol()
        {
            mennyiseg /= 2;
        }

        public override string ToString()
        {
            return "Pogacsa " + base.ToString();
        }
    }
}
