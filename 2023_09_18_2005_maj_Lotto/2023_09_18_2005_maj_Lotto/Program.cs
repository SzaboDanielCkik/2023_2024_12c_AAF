using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_09_18_2005_maj_Lotto
{
    class Program
    {
        static List<int> szamok;
        static List<List<int>> adatok = new List<List<int>>();
        static int[] darabok = new int[90];
        static void Main(string[] args)
        {
            Feladat1();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat8_1();
            Feladat8_2();
            Feladat9();

            Console.ReadLine();
        }

        private static void Feladat9()
        {
            List<int> primek = new List<int>{2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89 };

            PrimekKigyujt(primek);

            for (int i = 0; i < primek.Count; i++)
                Console.Write(primek[i] + " ");
            Console.WriteLine();
        }

        static void PrimekKigyujt(List<int> primek)
        {
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < adatok[i].Count; j++)
                    if (primek.Contains(adatok[i][j]))
                        primek.Remove(adatok[i][j]);
            }
        }

        private static void Feladat8_2()
        {
            for (int i = 0; i < darabok.Length; i++)
            {
                Console.Write(darabok[i]+ ((i+1)%15 != 0?" ":"\n"));
            }
        }

        private static void Feladat8_1()
        {
            for(int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < adatok[i].Count; j++)
                    darabok[adatok[i][j] - 1]++;
            }
        }

        private static void Feladat8()
        {
            StreamReader f = new StreamReader("lotto52.ki");

            adatok.Clear();
            while (!f.EndOfStream)
            {
                string line = f.ReadLine();
                adatok.Add(Array.ConvertAll(line.Split(' '), Convert.ToInt32).ToList());
            }

            f.Close();
        }

        private static void Feladat7()
        {
            StreamWriter g = new StreamWriter("lotto52.ki");
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < adatok[i].Count; j++)
                    g.Write(adatok[i][j] + (j == adatok[i].Count - 1 ? "" : " "));
                g.WriteLine();
            }
            for (int i = 0; i < szamok.Count; i++)
                g.Write(szamok[i] + (i == szamok.Count-1 ? "":" "));
            g.Close();
        }

        private static void Feladat6()
        {
            Console.WriteLine(ParatlanDb() + " darab páratlan szám van a kihúzott számok között.");
        }
        static int ParatlanDb()
        {
            int db = 0;
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < adatok[i].Count; j++)
                    db += Convert.ToInt32(adatok[i][j] % 2 == 1);
            }
            return db;
        }

        static void Feladat5()
        {
            bool[] joe = new bool[90];
            for (int i = 0; i < adatok.Count; i++)
            {
                for (int j = 0; j < adatok[i].Count; j++)
                {
                    int index = adatok[i][j] - 1;
                    joe[index] = true;
                }
            }
            Console.WriteLine(joe.ToList().Contains(false) ? "Van":"Nincs");
        }

        private static void Feladat3()
        {
            try
            {
                StreamReader f = new StreamReader("lottosz.dat");
                while (!f.EndOfStream)
                {
                    adatok.Add(Array.ConvertAll(f.ReadLine().Split(' '), Convert.ToInt32).ToList());
                }
                f.Close();
            }
            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Feladat4()
        {
            Console.WriteLine("Adjon meg egy számot [1,51] között: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;
            for (int i = 0; i < adatok[index].Count; i++)
                Console.Write(adatok[index][i] + " ");
            Console.WriteLine();
        }

        private static void Feladat2()
        {
            szamok.Sort();
            //szamok = szamok.OrderBy(c => c).ToList();
            for (int i = 0; i < szamok.Count; i++)
                Console.Write(szamok[i]+ (i == szamok.Count-1 ? "\n" : " "));
            //szamok.ForEach(c => Console.Write(c + " "));
            //Console.WriteLine();
        }

        private static void Feladat1()
        {
            Console.Write("Adja meg az 52. heti nyerő számokat: ");
            szamok = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32).ToList();
        }
    }
}
