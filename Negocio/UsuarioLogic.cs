using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class UsuarioLogic:BusinessLogic
    {
        public UsuarioAdapter UsuarioData;
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }
        public Usuario GetOne(int idUsuario)
        {
            return UsuarioData.GetOne(idUsuario);
        }
        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }
        public void Save(Usuario user)
        {
            UsuarioData.Save(user);
        }
        public void Delete(int idUser)
        {
            UsuarioData.Delete(idUser);
        }
        public Usuario GetOneByUserAndPassword(string username, string pass)
        {
            return UsuarioData.GetOneByUserAndPassword(username, pass);
        }
        public int getPermisos(int idUsuario)
        {
            return UsuarioData.getPermisos(idUsuario);
        }
    }
}
