using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_10_03_OsztalyGyak
{
    class Program
    {
        static void Main(string[] args)
        {
            Vektor v1 = new Vektor(2,3);
            Console.WriteLine(v1.ToString());
            double nv1, nv2;
            (nv1, nv2) = v1.NormalVektor();
            Console.WriteLine("({0},{1})", nv1, nv2);
            // E - fájlbeolvasás
            // Fv- leghosszabb vektor indexe
            // Ha a vektorokat összeadom, az elsőtől az utolsóig, hova fog mutatni az összeg vektor?
            Console.ReadLine();
        }
    }

    class Vektor
    {
        //Mezők - tulajdonságok - jellemzők
        private double x, y;

        //getter, setter
        public double X { 
            get { return x; }
            //set { x = value; }
        }

        //Konstruktor
        public Vektor(double x, double y) {
            this.x = x;
            this.y = y;
            /*double nx, ny;
            (nx, ny) = NormalVektor();*/
        }

        //Metódusok
        public (double, double) NormalVektor()
        {
            return (y, -x);
        }

        public string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}
