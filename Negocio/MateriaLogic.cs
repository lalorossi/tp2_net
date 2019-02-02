using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaAdapter MateriaData;
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }
        public Materia GetOne(int idMateria)
        {
            return MateriaData.GetOne(idMateria);
        }
        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }
        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }
        public void Delete(int idMat)
        {
            MateriaData.Delete(idMat);
        }
    }
}
