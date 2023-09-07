using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_07_OsszetettAdaszerkezetekIsm
{
    class Program
    {
        static List<List<int>> t = new List<List<int>>();

        static void Main(string[] args)
        {
            /*byte a = 238;
            byte b = 97;
            Console.WriteLine("{0} + {1} = {2}",a,b,(byte)(a+b));

            uint c = 2100000000;
            uint d = 2100000001;
            Console.WriteLine(c + d);*/

            MatrixFeltotles(t,5,3);

            

            Console.ReadLine();


        }

        private static void MatrixFeltotles(List<List<int>> t, int v1, int v2)
        {
            Random r = new Random();
            for (int i = 0; i < v1; i++)
            {
                t.Add(new List<int>());
                for (int j = 0; j < v2; j++)
                {
                    t[i].Add(r.Next(100));
                }
            }
        }
    }
}
