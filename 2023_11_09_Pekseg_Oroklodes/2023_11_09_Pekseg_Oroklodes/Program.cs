using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_09_Pekseg_Oroklodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Pogacsa p = new Pogacsa(5, 2);
            Console.WriteLine( p.ToString());

            Pekseg.Vasarlok("adatok.txt");
            Pekseg.EtelLeltar();


            Console.ReadLine();
        }
    }
}
