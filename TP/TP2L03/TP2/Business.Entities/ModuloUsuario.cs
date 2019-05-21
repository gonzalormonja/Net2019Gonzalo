using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _idUsuario;
        public int idUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        private int _idModulo;
        public int idModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }
        private Boolean _PermiteAlta;
        public Boolean PermiteAlta
        {
            get { return _PermiteAlta; }
            set { _PermiteAlta = value; }
        }
        private Boolean _PermiteBaja;
        public Boolean PermiteBaja
        {
            get { return _PermiteBaja; }
            set { _PermiteBaja = value; }
        }
        private Boolean _PermiteModificacion;
        public Boolean PermiteModificacion
        {
            get { return _PermiteModificacion; }
            set { _PermiteModificacion = value; }
        }
        private Boolean _PermiteConsulta;
        public Boolean PermiteConsulta
        {
            get { return _PermiteConsulta; }
            set { _PermiteConsulta = value; }
        }
    }
}
