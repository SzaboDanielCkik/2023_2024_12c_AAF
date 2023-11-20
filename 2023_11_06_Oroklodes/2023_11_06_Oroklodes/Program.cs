using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_06_Oroklodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Ososztaly o1 = new Ososztaly();
            o1.x = 12;
            Console.WriteLine(o1.ToString());

            Utodosztaly u1 = new Utodosztaly();
            u1.x = 13;
            u1.MegduplazX();
            u1.Valtoztatas();
            Console.WriteLine(u1.ToString());

            Ososztaly o2 = u1;
            


            Console.ReadLine();
        }
    }

    class Ososztaly
    {
        //Mezők
        public int x;
        protected int y = 17;
        //Konstruktor

        //Metódusok

        public void MegduplazX()
        {
            x *= 2;
        }

        public override string ToString()
        {
            return x + " " + y;
        }
    }

    class Utodosztaly : Ososztaly
    {
        //Mezők
        public int a;
        //Konstruktor

        //Metódusok
        public void Valtoztatas()
        {
            //y = 23;
            Console.WriteLine(y);
            a = x * 2 + y;
        }

        /*public void MegduplazX()
        {
            x *= 3;
        }*/

        public override string ToString()
        {
            return x + " " + a;
        }
    }
}
