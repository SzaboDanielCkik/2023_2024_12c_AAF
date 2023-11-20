using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2023_11_09_Pekseg_Oroklodes
{
    class Pekseg
    {
        public static List<IArlap> termekek = new List<IArlap>();


        public static void EtelLeltar()
        {
            StreamWriter g = new StreamWriter("leltar.txt");

            foreach (object c in termekek)
                if (c.GetType() == typeof(Pogacsa))
                    g.WriteLine(c.ToString());

            g.Close();
        }

        public static void Vasarlok(string utvonal)
        {
            StreamReader f = new StreamReader(utvonal);

            try
            {
                while (!f.EndOfStream)
                {
                    string sor = f.ReadLine();
                    if (sor.Contains("Pogacsa"))
                        termekek.Add(new Pogacsa(Convert.ToInt32(sor.Split(' ')[1]), Convert.ToInt32(sor.Split(' ')[2])));
                    else if (sor.Contains("Kave"))
                        termekek.Add(new Kave(sor.Contains("nem")));
                }

            }
            catch
            {
                Console.WriteLine("Beolvasási hiba!");
            }
            f.Close();
        }


        
    }
}
