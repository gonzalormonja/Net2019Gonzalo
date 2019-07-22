using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            leer();
            Console.ReadKey();

            escribir();
            leer();
            Console.ReadKey();

        }

        private static void leer()
        {
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            }
            while (linea != null);
            lector.Close();
        }

        private static void escribir()
        {
            StreamWriter escritor = File.AppendText("agenda.txt");
            Console.WriteLine("Ingrese nuevos contatos");
            string rta = "S";
            while (rta == "S")
            {
                Console.Write("Ingrese Nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese Apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese e-mail");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Ingrese Telefono");
                string telefono = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono);

                Console.Write("Desea ingresar otro contacto (S/N)");
                rta = Console.ReadLine();
            }

            escritor.Close();

        }
    }
}
