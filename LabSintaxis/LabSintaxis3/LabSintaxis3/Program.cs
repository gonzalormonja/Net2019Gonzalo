using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            String[] arrayString = new String[cantIteraciones];
            for (int i = 0; i < cantIteraciones; i++)
            {
                Console.WriteLine("Ingrese el " + (int)(i+1) + "° elemento");
                arrayString[i] = Console.ReadLine();
            }
            for (int j = 0; j < arrayString.Length; j++)
            {
                Console.WriteLine(arrayString[j]);
            }
        }
    }
}

