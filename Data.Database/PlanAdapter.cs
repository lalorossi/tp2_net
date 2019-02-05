using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select * from planes where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                if (drPlan.Read())
                {
                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    plan.IDEspecialidad= (int)drPlan["id_especialidad"];
                }

                drPlan.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del plan", ex);
                throw ex;
            }

            this.CloseConnection();
            return plan;
        }
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("select * from planes", sqlConn);

                SqlDataReader drPlanes = cmdPlan.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];

                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del plan", ex);
            }
            this.CloseConnection();
            return planes;
        }
        public void Delete(int IDPlan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDPlan;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminarel plan", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE planes SET desc_plan = @descripcion, id_especialidad = @id_especialidad, " +
                    "WHERE id_plan = @id_plan", sqlConn
                );

                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = plan.ID;
                cmdUpdate.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = plan.Descripcion;
                cmdUpdate.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el plan", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO planes (desc_plan, id_especialidad) " +
                    "VALUES (@descripcion, @id_especialidad) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@id_materia", SqlDbType.Int).Value = plan.ID;
                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar).Value = plan.Descripcion;
                plan.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el plan", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
