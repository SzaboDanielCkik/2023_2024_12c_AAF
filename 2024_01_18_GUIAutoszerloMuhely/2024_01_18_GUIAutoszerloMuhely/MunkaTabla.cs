using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_01_18_GUIAutoszerloMuhely
{
    class MunkaTabla
    {
        // Mezők
        public List<Szerelo> szerelok = new List<Szerelo>();

        //Konstruktor
        public MunkaTabla()
        {
            szerelok = Szerelo.FajlbeolvasasSzerelok("szerelok.txt");   
        }

        public MunkaTabla(string path)
        {
            szerelok = Szerelo.FajlbeolvasasSzerelok(path);
        }

        public List<Szerelo> RendezNevSzerint(bool novekvo)
        {
            return novekvo ?
                szerelok.OrderBy(c => c.Nev).ToList() :
                szerelok.OrderByDescending(c => c.Nev).ToList();
        }

        public List<Szerelo> RendezMunkakorSzerint(bool novekvo)
        {
            return novekvo ?
                szerelok.OrderBy(c => c.Munkakor).ToList() :
                szerelok.OrderByDescending(c => c.Munkakor).ToList();
        }

        public Szerelo KeresSzerelo(string nev)
        {
            return szerelok.Where(c => c.Nev == nev).First();
        }

        public List<Szerelo> MunkakorKeres(string munkakor)
        {
            List<Szerelo> sv = szerelok.Where(c => c.Munkakor == munkakor).ToList();
            return sv;
        }

        public bool TorolSzerelo(Szerelo szerelo)
        {
            return szerelok.Remove(szerelo);
        }

        public bool Valtoztat(Szerelo szerelo, string ujMunkakor)
        {
            int index = szerelok.IndexOf(szerelo);
            if (index > -1)
            {
                szerelok[index].Munkakor = ujMunkakor;
                return true;
            }
            return false;
        }

        public bool UjSzereloFelvetele(string nev, string munkakor)
        {
            try
            {
                Szerelo ujSzerelo = new Szerelo(nev, munkakor);
                szerelok.Add(ujSzerelo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int SzerelokOsszSzabadOraja()
        {
            return szerelok.Sum(c => c.beosztas.Sum(d => d.idopontok.Count(e => e)));
        }

        public bool SzereloFoglalas(string munkakor, string datum, int kezdes, int veg)
        {
            List<Szerelo> munkakorSzerelok = MunkakorKeres(munkakor).Where(c=> c.SzabadENaponOrakban(datum,kezdes,veg)).ToList();
            if (munkakorSzerelok.Count == 0)
                return false;
            else
            {
                List<bool> idopontok = munkakorSzerelok.First().beosztas.Where(c => c.Datum == datum).First().idopontok;
                Foglal(idopontok, kezdes-1, veg-1);


                return true;
            }            
        }

        static void Foglal(List<bool> idopontok, int kezdesIndex, int vegIndex)
        {
            for (int i = kezdesIndex; i <= vegIndex; i++)
                idopontok[i] = false;
        }

    }
}
