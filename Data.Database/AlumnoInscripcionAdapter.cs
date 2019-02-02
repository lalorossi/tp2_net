using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdAluInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drAluInscripcion = cmdAluInscripcion.ExecuteReader();

                if (drAluInscripcion.Read())
                {
                    ai.ID = (int)drAluInscripcion["id_inscripcion"];
                    ai.IDAlumno = (int)drAluInscripcion["id_alumno"];
                    ai.IDCurso = (int)drAluInscripcion["id_curso"];
                    ai.Condicion = drAluInscripcion["condicion"].ToString();
                    ai.Nota = (int)drAluInscripcion["nota"];
                    ai.fechaCambio = (DateTime)drAluInscripcion["fecha_cambio"];
                }

                drAluInscripcion.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del objeto", ex);
                throw ex;
            }

            this.CloseConnection();
            return ai;
        }
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> aluInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripciones = new SqlCommand("select * from alumnos_inscripciones", sqlConn);

                SqlDataReader drAluInscripciones = cmdAluInscripciones.ExecuteReader();

                while (drAluInscripciones.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)drAluInscripciones["id_inscripcion"];
                    ai.IDAlumno = (int)drAluInscripciones["id_alumno"];
                    ai.IDCurso = (int)drAluInscripciones["id_curso"];
                    ai.Condicion = drAluInscripciones["condicion"].ToString();
                    ai.Nota = (int)drAluInscripciones["nota"];
                    ai.fechaCambio = (DateTime)drAluInscripciones["fecha_cambio"];

                    aluInscripciones.Add(ai);
                }

                drAluInscripciones.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del objeto", ex);
            }
            this.CloseConnection();
            return aluInscripciones;
        }
        public void Delete(int IDAlumnoInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion= @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDAlumnoInscripcion;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE alumnos_inscripciones SET id_alumno = @id_alumno, id_curso = @id_curso, " +
                    "condicion = @condicion, nota = @nota, fecha_cambio = @fecha_cambio " +
                    "WHERE id_inscripcion= @id", sqlConn
                );

                cmdUpdate.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IDAlumno;
                cmdUpdate.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IDCurso;
                cmdUpdate.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumnoInscripcion.Condicion;
                cmdUpdate.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                cmdUpdate.Parameters.Add("@fecha_cambio", SqlDbType.Date).Value = alumnoInscripcion.fechaCambio;
                cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = alumnoInscripcion.ID;
                
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();

        }
        public void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota, fecha_cambio) " +
                    "VALUES (@id_alumno, @id_curso, @condicion, @nota, @fecha_cambio) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IDAlumno;
                cmdInsert.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IDCurso;
                cmdInsert.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumnoInscripcion.Condicion;
                cmdInsert.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                cmdInsert.Parameters.Add("@fecha_cambio", SqlDbType.DateTime).Value = alumnoInscripcion.fechaCambio;
                alumnoInscripcion.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el objeto", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            if (alumnoInscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(alumnoInscripcion);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnoInscripcion.ID);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(alumnoInscripcion);
            }
            alumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }

        public List<AlumnoInscripcion> FindCursos(int IDAlumno)
        {
            // Devuelve todas las relaciones para un docente

            List<AlumnoInscripcion> alumnosInscripcion = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno = @id_alumno", sqlConn);

                cmdAluInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;

                SqlDataReader drAluInscripcion = cmdAluInscripcion.ExecuteReader();

                while (drAluInscripcion.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)drAluInscripcion["id_inscripcion"];
                    ai.IDAlumno = (int)drAluInscripcion["id_alumno"];
                    ai.IDCurso = (int)drAluInscripcion["id_curso"];
                    ai.Condicion = drAluInscripcion["condicion"].ToString();
                    ai.Nota = (int)drAluInscripcion["nota"];
                    ai.fechaCambio = (DateTime)drAluInscripcion["fecha_cambio"];
                    alumnosInscripcion.Add(ai);
                }

                drAluInscripcion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del objeto", ex);
            }
            this.CloseConnection();
            return alumnosInscripcion;

        }

        public List<AlumnoInscripcion> FindAlumnos(int IDCurso)
        {
            // Devuelve todas las relaciones para un docente

            List<AlumnoInscripcion> alumnosInscripcion = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_curso = @id_curso", sqlConn);

                cmdAluInscripcion.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;

                SqlDataReader drAluInscripcion = cmdAluInscripcion.ExecuteReader();

                while (drAluInscripcion.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)drAluInscripcion["id_inscripcion"];
                    ai.IDAlumno = (int)drAluInscripcion["id_alumno"];
                    ai.IDCurso = (int)drAluInscripcion["id_curso"];
                    ai.Condicion = drAluInscripcion["condicion"].ToString();
                    ai.Nota = (int)drAluInscripcion["nota"];
                    ai.fechaCambio = (DateTime)drAluInscripcion["fecha_cambio"];

                    alumnosInscripcion.Add(ai);
                }

                drAluInscripcion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos del objeto", ex);
            }
            this.CloseConnection();
            return alumnosInscripcion;

        }

        public AlumnoInscripcion FindSingle(int IDAlumno, int IDCurso)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_alumno = @id_alumno and id_curso = @id_curso", sqlConn);
                cmdAluInscripcion.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                cmdAluInscripcion.Parameters.Add("@id_curso", SqlDbType.Int).Value = IDCurso;

                SqlDataReader drAluInscripcion = cmdAluInscripcion.ExecuteReader();

                if (drAluInscripcion.Read())
                {
                    ai.ID = (int)drAluInscripcion["id_inscripcion"];
                    ai.IDAlumno = (int)drAluInscripcion["id_alumno"];
                    ai.IDCurso = (int)drAluInscripcion["id_curso"];
                    ai.Condicion = drAluInscripcion["condicion"].ToString();
                    ai.Nota = (int)drAluInscripcion["nota"];
                    ai.fechaCambio = (DateTime)drAluInscripcion["fecha_cambio"];
                }

                drAluInscripcion.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del objeto", ex);
                throw ex;
            }

            this.CloseConnection();
            return ai;
        }
        /*
        public Object getModifiedDate(int ID)
        {
            Object modifiedDate = new Object();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAluInscripcion = new SqlCommand("select [modify_date] from alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdAluInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drAluInscripcion = cmdAluInscripcion.ExecuteReader();

                if (drAluInscripcion.Read())
                {
                    modifiedDate = (drAluInscripcion["modify_date"]);
                }

                drAluInscripcion.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del objeto", ex);
                throw ex;
            }

            this.CloseConnection();
            return modifiedDate;
        }
        */
    }
}