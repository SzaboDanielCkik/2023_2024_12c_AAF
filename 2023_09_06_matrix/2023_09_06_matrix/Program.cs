using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_06_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //Egy feltöltött matrixról döntsd el, hogy melyik a nagyobb, a sorok átlagának legnagyobb értéke vagy az osztlopok átlagának legnagyobb értéke?
            int a = 12;
            int b = 13;
            Console.WriteLine(a < b ? "az első kisebb" : "második kisebb");
        }
    }
}
