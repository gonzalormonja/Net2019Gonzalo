using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ingrese el primer numero: ");
            float primero = float.Parse(Console.ReadLine());
            Console.WriteLine("ingrese el segundo numero: ");
            float segundo = float.Parse(Console.ReadLine());
            Console.WriteLine("El resultado de la suma de " + primero + " y " + segundo + " es " + (primero + segundo));
        }
    }
}
