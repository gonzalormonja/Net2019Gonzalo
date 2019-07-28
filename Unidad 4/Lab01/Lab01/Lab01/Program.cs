﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*leer();
            Console.ReadKey();
            escribir();
            leer();
            Console.ReadKey();*/

            Console.WriteLine("Presione una tecla para generar el archivo agendaxml.xml con los datos de agenda.txt");
            Console.ReadKey();
            escribirXML();
            Console.WriteLine("Archivo agendaxml.xml generado correctamente\n\nPresione una tecla para ver su contenido");
            Console.ReadKey();
            Console.WriteLine();
            leerXML();
            Console.ReadKey();



        }

        private static void escribirXML()
        {
            XmlTextWriter escritorXML = new XmlTextWriter("agendaxml.xml", null);
            escritorXML.Formatting = Formatting.Indented;
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    escritorXML.WriteStartElement("contactos");
                    escritorXML.WriteStartElement("nombre");
                    escritorXML.WriteValue(valores[0]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("email");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteEndElement();
                }

            }
            while (linea != null);
            escritorXML.WriteEndElement();
            escritorXML.WriteEndDocument();
            escritorXML.Close();
        }

        private static void leerXML()
        {
            XmlTextReader lectorXML = new XmlTextReader("agendaxml.xml");

            string tagAnterior = "";
            while (lectorXML.Read())
            {
                if (lectorXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = lectorXML.Name;
                }
                else if (lectorXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + lectorXML.Value);

                }
            }
            lectorXML.Close();
        }
        

        private static void leer()
        {
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            Console.WriteLine("Nombre\tApellido\te-mail\t\t\tTelefono");
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
