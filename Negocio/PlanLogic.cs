using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class PlanLogic : BusinessLogic
    {
        public PlanAdapter PlanData;
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }
        public Plan GetOne(int idPlan)
        {
            return PlanData.GetOne(idPlan);
        }
        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }
        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
        public void Delete(int idPlan)
        {
            PlanData.Delete(idPlan);
        }
    }
}
