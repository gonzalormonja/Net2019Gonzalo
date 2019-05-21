﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        private Data.Database.UsuarioAdapter _UsuarioData;

        public UsuarioLogic()
        {
            _UsuarioData = new UsuarioAdapter();
        }
        public Usuario GetOne(int ID)
        {
            return _UsuarioData.GetOne(ID);
        }
        public List<Usuario> GetAll()
        {
            return _UsuarioData.GetAll();
        }
        public void Save(Usuario usuario)
        {
            _UsuarioData.Save(usuario);
        }
        public void Delete(int ID)
        {
            _UsuarioData.Delete(ID);
        }
    }
}
