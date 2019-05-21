using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario
    {
        private String _NombreUsuario;
        public String NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        private String _Clave;
        public String Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        private String _Nombre;
        public String Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        private String _Apellido;
        public String Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        private String _Email;
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private Boolean _Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

    }

}
