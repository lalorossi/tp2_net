using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class DocenteCursoLogic : BusinessLogic
    {
        public DocenteCursoAdapter DocenteCursoData;
        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }
        public DocenteCurso GetOne(int idDocenteCurso)
        {
            return DocenteCursoData.GetOne(idDocenteCurso);
        }
        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }
        public void Save(DocenteCurso docenteCurso)
        {
            DocenteCursoData.Save(docenteCurso);
        }
        public void Delete(int idDocenteCurso)
        {
            DocenteCursoData.Delete(idDocenteCurso);
        }
        public DocenteCurso FindDocente(int idCurso)
        {
            return DocenteCursoData.FindDocente(idCurso);
        }
        public List<DocenteCurso> FindCursos(int idDocente)
        {
            return DocenteCursoData.FindCursos(idDocente);
        }
    }
}