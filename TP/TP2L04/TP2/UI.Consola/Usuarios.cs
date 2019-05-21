using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
namespace UI.Consola
{
    public class Usuarios
    {
        UsuarioLogic UsuarioNegocio;
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu()
        {
           
            Boolean ejecutar = true;
            while (ejecutar) {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1– Listado General");
                    Console.WriteLine("2– Consulta");
                    Console.WriteLine("3– Agregar");
                    Console.WriteLine("4 - Modificar");
                    Console.WriteLine("5 - Eliminar");
                    Console.WriteLine("6 - Salir");
                    ConsoleKeyInfo opcion = Console.ReadKey();
                    Console.Clear();
                    switch (opcion.Key)
                    {
                        case ConsoleKey.D1:
                            ListadoGeneral();
                            break;
                        case ConsoleKey.D2:
                            Consultar();
                            break;
                        case ConsoleKey.D3:
                            Agregar();
                            break;
                        case ConsoleKey.D4:
                            Modificar();
                            break;
                        case ConsoleKey.D5:
                            Eliminar();
                            break;
                        case ConsoleKey.D6:
                            ejecutar = false;
                            break;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("El id ingresado no pertenece a ningun usuario");
                }
                catch (FormatException)
                {
                    Console.WriteLine("La ID ingresada debe ser un número entero");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("Precione una tecla para continuar");
                    Console.ReadKey();
                }
            }
        }

        public void ListadoGeneral()
        {
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}",usr.ID);
            Console.WriteLine("\t\tNombre: {0}",usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}",usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}",usr.Clave);
            Console.WriteLine("\t\tEmail: {0}",usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}",usr.Habilitado);
        }
        public void Consultar()
        {
            
            Console.WriteLine("Ingrese el ID del usuario a consultar");
            int ID = int.Parse(Console.ReadLine());
            this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            
        }
        public void Modificar()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del usuario a modificar");
            int ID = int.Parse(Console.ReadLine());
            Usuario usuario = UsuarioNegocio.GetOne(ID);
            Console.Write("Ingrese el nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese el nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese la clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese el email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de usuario(1-Si/2-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.Modified;
            UsuarioNegocio.Save(usuario);
        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Write("Ingrese el nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese el nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese la clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese el email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitacion de usuario(1-Si/2-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
            Console.ReadKey();
        }

        public void Eliminar()
        {
            Console.Write("Ingrese el ID del usuario a eliminar: ");
            int ID = int.Parse(Console.ReadLine());
            UsuarioNegocio.Delete(ID);
        }
    }
    
}
