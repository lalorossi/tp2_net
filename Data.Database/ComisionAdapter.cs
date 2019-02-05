using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from comisiones where id_comision = @id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drComision = cmdCurso.ExecuteReader();

                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];
                }

                drComision.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", ex);
                throw ex;
            }

            this.CloseConnection();
            return com;
        }
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from comisiones", sqlConn);

                SqlDataReader drComision = cmdCurso.ExecuteReader();

                while (drComision.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];

                    comisiones.Add(com);
                }

                drComision.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la comision", ex);
            }
            this.CloseConnection();
            return comisiones;
        }
        public void Delete(int IDComision)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision = @id");
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDComision;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Comision curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE comisiones SET id_comision = @id_comision, descripcion = @descripcion, " +
                    "anio_especialidad = @anio_especialidad, id_plan = @id_plan" +
                    "WHERE id_comision = @id_comision", sqlConn
                );

                cmdUpdate.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.ID;
                cmdUpdate.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = curso.Descripcion;
                cmdUpdate.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = curso.AnioEspecialidad;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = curso.IDPlan;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la comision", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO comisiones (id_comision, descripcion, anio_especialidad, id_plan) " +
                    "VALUES (@id_comision, @descripcion, @anio_especialidad, @id_plan) " +
                    "select @@identity" // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.ID;
                cmdInsert.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = comision.Descripcion;
                cmdInsert.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                comision.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la comision", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Comision curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
        public List<Comision> ComisionesDePlan(int IDPlan)
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from comisiones where id_plan = @idPlan", sqlConn);

                cmdCurso.Parameters.Add("@idPlan", SqlDbType.Int).Value = IDPlan;

                SqlDataReader drComision = cmdCurso.ExecuteReader();

                while (drComision.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];

                    comisiones.Add(com);
                }

                drComision.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la comision", ex);
            }
            this.CloseConnection();
            return comisiones;
        }
    }
}
