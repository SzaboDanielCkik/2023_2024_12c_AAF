using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_16_Linq_gyakorlas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> t = new List<int>() { 13, 17, 26, 28, 31, 46 };
            //Any - Eldöntés - True, False
            Console.WriteLine(t.Any(c=>c>=45));
            Console.WriteLine(t.Any(c => c % 3 == 0));

            //Aggregate - Feltételnek megfelelően fut le a folyamat
            // Hány darab páros szám van? - egész szám
            Console.WriteLine(t.Aggregate(0,(db, c) =>
                            c % 2 == 0 ? db + 1 : db));
            //Gyümölcsök 
            List<string> gyumolcsok = new List<string>()
            {"alma", "banán", "eper","szilva", "paradicsom", "dinnye" };
            // Valaminél hosszabb szót
            Console.WriteLine(gyumolcsok.Aggregate("körte",(gy, c) =>
            gy.Length<c.Length ? c : gy ));



            Console.ReadLine();
        }
    }
}
