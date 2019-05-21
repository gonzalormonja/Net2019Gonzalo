using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un texto");
            String inputTexto = Console.ReadLine();
            if (inputTexto.Length > 0)
            {
                Console.WriteLine("Seleccione que desea hacer con el texto: ");
                Console.WriteLine("1. Mostrar texto en mayuscula.");
                Console.WriteLine("2. Mostrar texto en minuscula.");
                Console.WriteLine("3. Mostrar cantidad de caracteres.");
                ConsoleKeyInfo opcion = Console.ReadKey();
                Console.WriteLine();
                if (opcion.Key == ConsoleKey.D1)
                {
                    Console.WriteLine(inputTexto.ToUpper());
                }
                else if (opcion.Key == ConsoleKey.D2)
                {

                    Console.WriteLine(inputTexto.ToLower());
                }
                else if (opcion.Key == ConsoleKey.D3)
                {

                    Console.WriteLine(inputTexto.Length);
                }
                else
                {
                    Console.WriteLine("No selecciono una opcion valida");
                }
            }
            else
            {
                Console.WriteLine("No ingreso ningun texto.");
            }
        }
    }
}
