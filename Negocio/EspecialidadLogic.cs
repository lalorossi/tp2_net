using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadAdapter EspecialidadData;
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }
        public Especialidad GetOne(int idUsuario)
        {
            return EspecialidadData.GetOne(idUsuario);
        }
        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }
        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
        public void Delete(int idUser)
        {
            EspecialidadData.Delete(idUser);
        }
    }
}
