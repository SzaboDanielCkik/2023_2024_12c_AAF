using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_06_Oroklodes2
{
    // Ősosztály - absztrakt
    abstract class Ososztaly
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Ososztaly(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Rajzol();
    }
}
