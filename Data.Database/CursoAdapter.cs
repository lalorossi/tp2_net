using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public Curso GetOne(int ID)
        {
            Curso crs = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                if (drCurso.Read())
                {
                    crs.ID = (int)drCurso["id_curso"];
                    crs.IDMateria = (int)drCurso["id_materia"];
                    crs.IDComision = (int)drCurso["id_comision"];
                    crs.AnioCalendario = (int)drCurso["anio_calendario"];
                    crs.Cupo = (int)drCurso["cupo"];
                }

                drCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", ex);
                throw ex;
            }

            this.CloseConnection();
            return crs;
        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCurso = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                while (drCurso.Read())
                {
                    Curso crs = new Curso();
                    crs.ID = (int)drCurso["id_curso"];
                    crs.IDMateria = (int)drCurso["id_materia"];
                    crs.IDComision = (int)drCurso["id_comision"];
                    crs.AnioCalendario = (int)drCurso["anio_calendario"];
                    crs.Cupo = (int)drCurso["cupo"];

                    cursos.Add(crs);
                }

                drCurso.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del curso", ex);
            }
            this.CloseConnection();
            return cursos;
        }
        public void Delete(int IDCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDCurso;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, " +
                    "anio_calendario = @anio_calendario, cupo = @cupo " +
                    "WHERE id_curso = @id", sqlConn
                );

                cmdUpdate.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdUpdate.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdUpdate.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdUpdate.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el curso", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();

        }
        public void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO cursos (id_materia, id_comision, anio_calendario, cupo) " +
                    "VALUES (@id_materia, @id_comision, @anio_calendario, @cupo) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdInsert.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdInsert.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdInsert.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el curso", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Curso curso)
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
    }
}
