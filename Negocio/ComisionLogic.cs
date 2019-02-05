using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class ComisionLogic : BusinessLogic
    {
        public ComisionAdapter ComisionData;
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }
        public Comision GetOne(int idComision)
        {
            return ComisionData.GetOne(idComision);
        }
        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }
        public void Save(Comision com)
        {
            ComisionData.Save(com);
        }
        public void Delete(int idCom)
        {
            ComisionData.Delete(idCom);
        }
        public List<Comision> ComisionesDePlan(int IDPlan)
        {
            return ComisionData.ComisionesDePlan(IDPlan);
        }
    }
}
