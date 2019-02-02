using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspec = new SqlCommand("select * from especialidades where id_especialidad = @id", sqlConn);
                cmdEspec.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drEspec = cmdEspec.ExecuteReader();

                if (drEspec.Read())
                {
                    esp.ID = (int)drEspec["id_especialidad"];
                    esp.Descripcion = (string)drEspec["desc_especialidad"];
                }

                drEspec.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", ex);
                throw ex;
            }

            this.CloseConnection();
            return esp;
        }
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspec = new SqlCommand("select * from especialidades", sqlConn);

                SqlDataReader drEspec = cmdEspec.ExecuteReader();

                while (drEspec.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)drEspec["id_especialidad"];
                    esp.Descripcion = (string)drEspec["desc_especialidad"];

                    especialidades.Add(esp);
                }

                drEspec.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la especialidad", ex);
            }
            this.CloseConnection();
            return especialidades;
        }
        public void Delete(int IDEspecialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDEspecialidad;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE especialidades SET desc_especialidad = @descripcion " +
                    "WHERE id_especialidad = @id_especialidad", sqlConn
                );
                cmdUpdate.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = especialidad.Descripcion;
                cmdUpdate.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = especialidad.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la especialidad", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO especialidades (desc_especialidad) " +
                    "VALUES (@descripcion) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la especialidad", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
