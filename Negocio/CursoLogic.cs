using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class CursoLogic : BusinessLogic
    {
        public CursoAdapter CursoData;
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }
        public Curso GetOne(int idUsuario)
        {
            return CursoData.GetOne(idUsuario);
        }
        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }
        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
        public void Delete(int idCurso)
        {
            CursoData.Delete(idCurso);
        }
    }
}
