using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_06_Oroklodes2
{
    class Program
    {
        static void Main(string[] args)
        {
            Teglalap t1 = new Teglalap(10, 10, 10, 5);
            t1.Rajzol();

            /* Hozz létre egy Négyzet nevő osztályt, ami tulajdonságra egyezik a 
             * téglalap osztállyal. (örökli)
             * A négyzet minden oldala egyenlő!
             * Majd a main eljárásban ellenőrizd a működését!*/

            Negyzet n1 = new Negyzet(5,5,4);
            n1.Rajzol();


            Console.ReadLine();
        }
    }

 

    
   
}
