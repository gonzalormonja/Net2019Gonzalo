using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            int f1 = 0;
            int f2 = 1;
            Console.WriteLine("Cuantos numeros de fibonacci quiere sumar?");
            int cantNumeros = int.Parse(Console.ReadLine());
            int suma = 0;
            for (int i = 0; i < cantNumeros-2; i++)
            {
                suma = f1 + f2;
                f1 = f2;
                f2 = suma;
            }
            Console.Write(suma);
        }
    }
}
