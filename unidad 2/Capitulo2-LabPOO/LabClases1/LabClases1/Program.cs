using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            A elemento = new A();
            elemento.NombreInstancia = "esto lo hice a mano";
            A elemento2 = new A("esto es automatico");
            B elemento3 = new B();
            elemento.mostrarNombre();
            elemento2.mostrarNombre();
            elemento3.mostrarNombre();
            elemento3.M1();
            elemento3.M2();
            elemento3.M3();
            elemento3.M4();

            Console.ReadKey();
        }
    }
}
