using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
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
                switch (opcion.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine(inputTexto.ToUpper());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(inputTexto.ToLower());
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine(inputTexto.Length);
                        break;
                    default:
                        Console.WriteLine("No selecciono una opcion valida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No ingreso ningun texto.");
            }
        }
    }
}