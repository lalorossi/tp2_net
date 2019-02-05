using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                if (drMateria.Read())
                {
                    mat.ID = (int)drMateria["id_materia"];
                    mat.Descripcion = (string)drMateria["desc_materia"];
                    mat.HsSemanales = (int)drMateria["hs_semanales"];
                    mat.HsTotales = (int)drMateria["hs_totales"];
                    mat.IDPlan = (int)drMateria["id_plan"];
                }

                drMateria.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", ex);
                throw ex;
            }

            this.CloseConnection();
            return mat;
        }
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("select * from materias", sqlConn);

                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                while (drMateria.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMateria["id_materia"];
                    mat.Descripcion = (string)drMateria["desc_materia"];
                    mat.HsSemanales = (int)drMateria["hs_semanales"];
                    mat.HsTotales = (int)drMateria["hs_totales"];
                    mat.IDPlan = (int)drMateria["id_plan"];

                    materias.Add(mat);
                }

                drMateria.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la materia", ex);
            }
            this.CloseConnection();
            return materias;
        }
        public void Delete(int IDMateria)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDMateria;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE materias SET desc_materia = @desc_materia, " +
                    "hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan" +
                    "WHERE id_materia = @id_materia", sqlConn
                );

                cmdUpdate.Parameters.Add("@desc_materia", SqlDbType.VarChar).Value = materia.Descripcion;
                cmdUpdate.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdUpdate.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdUpdate.Parameters.Add("@id_materia", SqlDbType.Int).Value = materia.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la materia", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO materias (desc_materia, hs_semanales, hs_totales, id_plan) " +
                    "VALUES ( @desc_materia, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );
                
                cmdInsert.Parameters.Add("@desc_materia", SqlDbType.VarChar).Value = materia.Descripcion;
                cmdInsert.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HsSemanales;
                cmdInsert.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HsTotales;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la materia", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
        public List<Materia> MateriasDePlan(int IDPlan)
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_plan = @idPlan", sqlConn);

                cmdMateria.Parameters.Add("@idPlan", SqlDbType.Int).Value = IDPlan;

                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                while (drMateria.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMateria["id_materia"];
                    mat.Descripcion = (string)drMateria["desc_materia"];
                    mat.HsSemanales = (int)drMateria["hs_semanales"];
                    mat.HsTotales = (int)drMateria["hs_totales"];
                    mat.IDPlan = (int)drMateria["id_plan"];

                    materias.Add(mat);
                }

                drMateria.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la materia", ex);
            }
            this.CloseConnection();
            return materias;
        }
    }
}
