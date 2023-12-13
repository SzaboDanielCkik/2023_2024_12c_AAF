using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_20_Gepjarmu_Oroklodes
{
    class Orszagut
    {
        static List<Jarmu> jarmuvek = new List<Jarmu>();

        public static void JarmuvekJonnek(string path)
        {
            StreamReader f = new StreamReader(path);

            while (!f.EndOfStream)
            {
                string[] st = f.ReadLine().Split(';');
                if (st[0].Contains("robogo"))
                {
                    jarmuvek.Add(new Robogo(st[1], Convert.ToInt32(st[2]), Convert.ToInt32(st[3])));
                }
                else if (st[0].Contains("audi"))
                {
                    jarmuvek.Add(new AudiS8(st[1], Convert.ToInt32(st[2]), st[3] == "true"));
                }
            }

            f.Close();
        }

        public static void KiketMertunkBe()
        {
            StreamWriter g = new StreamWriter("buntetes.txt");

            jarmuvek.ForEach(c =>
            {
                if (c.GetType() == typeof(Robogo) && ((Robogo)c).HaladhatItt(90))
                    g.WriteLine(c.ToString());
                if (c.GetType() == typeof(AudiS8) && ((AudiS8)c).GyorshajtottE(90))
                    g.WriteLine(c.ToString());   
            });
            g.Close();
        }
    }
}
