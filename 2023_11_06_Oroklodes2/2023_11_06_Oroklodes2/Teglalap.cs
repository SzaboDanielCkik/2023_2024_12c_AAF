using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_06_Oroklodes2
{
    class Teglalap : Ososztaly
    {
        public int Szelesseg { get; private set; }
        public int Magassag { get; private set; }

        public Teglalap(int x, int y, int szel, int mag) : base(x, y)
        {
            Szelesseg = szel;
            Magassag = mag;
        }

        public override void Rajzol()
        {
            // téglalap kirajzolása
            Console.SetCursorPosition(X, Y);
            for (int i = 0; i < Magassag; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                for (int j = 0; j < Szelesseg; j++)
                {
                    if (i == 0 || i == Magassag - 1) Console.Write("-");
                    else
                    {
                        if (j == 0 || j == Szelesseg - 1) Console.Write("|");
                        else Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
