using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCurso = new SqlCommand("select * from docentes_cursos where id_dictado = @id", sqlConn);
                cmdDocCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();

                if (drDocCurso.Read())
                {
                    dc.ID = (int)drDocCurso["id_dictado"];
                    dc.IDCurso = (int)drDocCurso["id_curso"];
                    dc.IDDocente = (int)drDocCurso["id_docente"];
                    dc.Cargo = (int)drDocCurso["cargo"];
                }

                drDocCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del objeto", ex);
                throw ex;
            }

            this.CloseConnection();
            return dc;
        }
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCurso = new SqlCommand("select * from docentes_cursos", sqlConn);

                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();

                while (drDocCurso.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocCurso["id_dictado"];
                    dc.IDDocente = (int)drDocCurso["id_docente"];
                    dc.IDCurso= (int)drDocCurso["id_curso"];
                    dc.Cargo = (int)drDocCurso["cargo"];

                    docentesCursos.Add(dc);
                }

                drDocCurso.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del objeto", ex);
            }
            this.CloseConnection();
            return docentesCursos;
        }
        public void Delete(int IDDocCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDDocCurso;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE docentes_cursos SET id_docente = @id_docente, id_curso = @id_curso, " +
                    "cargo = @cargo " +
                    "WHERE id_dictado= @id", sqlConn
                );

                cmdUpdate.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdUpdate.Parameters.Add("@cargo", SqlDbType.VarChar).Value = docenteCurso.Cargo;
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.ID;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();

        }
        public void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO docentes_cursos (id_docente, id_curso, cargo) " +
                    "VALUES (@id_docente, @id_curso, @cargo) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdInsert.Parameters.Add("@cargo", SqlDbType.VarChar).Value = docenteCurso.Cargo;
                docenteCurso.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.ID);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }

        public List<DocenteCurso> FindCursos(int IDDocente)
        {
            // Devuelve todas las relaciones para un docente

            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCurso = new SqlCommand("select * from docentes_cursos where id_docente = @id_docente", sqlConn);

                cmdDocCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = IDDocente;

                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();

                while (drDocCurso.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)drDocCurso["id_dictado"];
                    dc.IDDocente = (int)drDocCurso["id_docente"];
                    dc.IDCurso = (int)drDocCurso["id_curso"];
                    dc.Cargo = (int)drDocCurso["cargo"];

                    docentesCursos.Add(dc);
                }

                drDocCurso.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del objeto", ex);
            }
            this.CloseConnection();
            return docentesCursos;

        }
        public DocenteCurso FindDocente(int IDCurso)
        {
            // devuelve la relacion específica de un curso

            DocenteCurso dc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                //Supone que hay un solo docente en cada curso
                SqlCommand cmdDocCurso = new SqlCommand("select * from docentes_cursos where id_curso = @id_curso", sqlConn);

                cmdDocCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;

                SqlDataReader drDocCurso = cmdDocCurso.ExecuteReader();

                if (drDocCurso.Read())
                {
                    dc.ID = (int)drDocCurso["id_dictado"];
                    dc.IDCurso = (int)drDocCurso["id_curso"];
                    dc.IDDocente = (int)drDocCurso["id_docente"];
                    dc.Cargo = (int)drDocCurso["cargo"];
                }

                drDocCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del objeto", ex);
                throw ex;
            }

            this.CloseConnection();
            return dc;

        }
    }
}
