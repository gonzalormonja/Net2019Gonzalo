using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Clases
{
    public class A
    {
        private String nombreInstancia;
        public String NombreInstancia
        {
            get
            {
                return nombreInstancia;    
            }
            
            set
            {
                nombreInstancia = value;
            }
        }
        public A()
        {
            nombreInstancia = "instancia sin nombre";
        }
        public A(String nombreInstancia)
        {
            this.nombreInstancia = nombreInstancia;
        }
        public void mostrarNombre()
        {
            Console.WriteLine(nombreInstancia);
        }
        public void M1()
        {
            Console.WriteLine("metodo M1 invocado");
        }
        public void M2()
        {
            Console.WriteLine("metodo M2 invocado");
        }
        public void M3()
        {
            Console.WriteLine("metodo M3 invocado");
        }
    }
}
