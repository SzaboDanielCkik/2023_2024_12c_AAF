using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_01_15_AutoszereloMuhely
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Beosztas b = new Beosztas("2024.01.15");
            b.Elfoglaltsag().ForEach(c => Console.WriteLine(c));*/

            //List<Szerelo> szerelok = Szerelo.FajlbeolvasasSzerelok("szerelok.txt");

            MunkaTabla tabla = new MunkaTabla("szerelok.txt");
            /*Console.WriteLine(   tabla.SzereloFoglalas("olajcsere", "2024.01.13", 3, 5));
            Console.WriteLine(tabla.SzereloFoglalas("olajcsere", "2024.01.13", 3, 4));*/



            Console.ReadLine();
        }
    }
}
