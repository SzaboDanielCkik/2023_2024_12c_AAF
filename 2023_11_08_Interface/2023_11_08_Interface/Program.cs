using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_08_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPreda i1 = new IPreda(); 
            Nyul ny = new Nyul();
            ny.Menekules();

            Solyom s = new Solyom();
            s.Vadaszat();

            Hal h = new Hal();
            h.Menekules();
            h.Vadaszat();

            Console.ReadLine();
        }

    }

    interface IPreda
    {
        void Menekules();
    }

    interface IRagadozo
    {
        void Vadaszat();
    }

    class Nyul : IPreda
    {
        public void Menekules()
        {
            Console.WriteLine("Veszely esetén elfut.");
        }
    }

    class Solyom : IRagadozo
    {
        public void Vadaszat()
        {
            Console.WriteLine("Elmegy a prédát becserkészni.");
        }
    }

    class Hal : IPreda, IRagadozo
    {
        public void Menekules()
        {
            Console.WriteLine("Veszely esetén elúszik.");
        }
        public void Vadaszat()
        {
            Console.WriteLine("Elmegy a más halacskákat megenni.");
        }
    }

}
