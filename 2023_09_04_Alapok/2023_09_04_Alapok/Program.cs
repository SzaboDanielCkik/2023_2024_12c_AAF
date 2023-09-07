using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_04_Alapok
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 11;
            int[] t = new int[n];
            int k = 30;
            Tombfeltotes(t, n, k);
            Feladat1(t);
            Feladat2(t);

            Console.ReadLine();
        }

        private static void Feladat2(int[] t)
        {
            // Rendezd a tömb elemeit csökkenő sorrendbe a megtanult algoritmussal!
            Console.WriteLine("A tömb elemei:");
            KiirTomb(t);
            Rendezes(t);
            Console.WriteLine("A rendezett tömb elemei:");
            KiirTomb(t);
        }

        private static void Rendezes(int[] t)
        {
            for (int i = t.Length-1; i > 0 ; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (t[i] > t[j])
                    {
                        //Csere(ref t[i], ref t[j]);
                        Csere(t, i, j);
                    }
                }
            }
        }
        private static void Csere(int[] t, int i, int j)
        {
            int sv = t[i];
            t[i] = t[j];
            t[j] = sv;
        }
        private static void Csere(ref int v1,ref int v2)
        {
            int sv = v1;
            v1 = v2;
            v2 = sv;
        }

        private static void KiirTomb(int[] t)
        {
            foreach (int elem in t)
                Console.Write(elem+" ");
            Console.WriteLine();
        }

        private static void Feladat1(int[] t)
        {
            int k = 23;
            //Van-e héttel osztható szám a tömbben?
            /*if(VaneOszthatoSzam(t, k))
                Console.WriteLine("Van {0} számmal osztható szám.",k);
            else
                Console.WriteLine("Nincs {0} számmal osztható szám.",k);*/
            if (t.ToList().Where(c=>c%k == 0).Count() > 0)
                Console.WriteLine("Van {0} számmal osztható szám.", k);
            else
                Console.WriteLine("Nincs {0} számmal osztható szám.", k);
        }

        private static bool VaneOszthatoSzam(int[] t, int k)
        {
            int i = 0;
            while (i < t.Length && t[i] % k != 0)
                i++;
            return i < t.Length;
        }

        private static void Tombfeltotes(int[] t, int n, int k)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
                t[i] = r.Next(k);
        }
    }
}
