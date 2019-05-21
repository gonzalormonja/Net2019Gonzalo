using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un año para comprobar si es bisiesto: ");
            int año = int.Parse(Console.ReadLine());

            if (año%4==0)
            {
                if (año%100==0)
                {
                    if (año%400==0)
                    {
                        Console.WriteLine("Es bisiesto");
                    }
                    else
                    {
                        Console.WriteLine("No es bisiesto");
                    }
                }
                else
                {
                    Console.WriteLine("Es bisiesto");
                }
            }
        }
    }
}
