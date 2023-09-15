using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2023_09_11_FajlbeolvasasIsm
{
    class Program
    {
        static List<Adat> t = new List<Adat>();

        static void Main(string[] args)
        {
            Fajlbeolvasas1();
            Fajlbeolvasas2();
            Fajlbeolvasas3();

            Console.ReadLine();
        }

        private static void Fajlbeolvasas3()
        {
            try
            {
                StreamReader f = new StreamReader("megoldas.txt");
                int db = Convert.ToInt32(f.ReadLine());
                while (!f.EndOfStream)
                {
                    Adat a = new Adat();
                    a.matrix = new int[10, 10];
                    a.nev = f.ReadLine();
                    for (int i = 0; i < 10; i++)
                    {
                        int[] szamok = Array.ConvertAll(f.ReadLine().Split(' '), Convert.ToInt32);
                        for (int j = 0; j < szamok.Length; j++)
                        {
                            a.matrix[i, j] = szamok[j];
                        }
                    }
                    t.Add(a);                        
                }
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Fajlbeolvasas2()
        {
            try
            {
                StreamReader f = new StreamReader("feladvany.txt");

                while (!f.EndOfStream)
                {
                    string sor = f.ReadLine();
                    string[] st = sor.Split(' ');
                    //...
                }

                f.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void Fajlbeolvasas1()
        {
            try
            {
                string[] osszessor = File.ReadAllLines("feladvany.txt");
            }
            catch(FileNotFoundException e /*Exception e*/)
            {
                Console.WriteLine("A megadott fájl az adott útvonalon nem elérhető.");
                Console.WriteLine(e.Message);
            }
        }
    }

    struct Adat
    {
        public string nev;
        public int[,] matrix;
    }
}
