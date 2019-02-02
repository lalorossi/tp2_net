using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public Personas GetOne(int ID)
        {
            Personas pers = new Personas();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    pers.ID = (int)drPersonas["id_persona"];
                    pers.Nombre = (string)drPersonas["nombre"];
                    pers.Apellido = (string)drPersonas["apellido"];
                    pers.Direccion = (string)drPersonas["direccion"];
                    pers.Telefono = (string)drPersonas["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    pers.Legajo = (int)drPersonas["legajo"];
                    pers.TipoPersona = (int)drPersonas["tipo_persona"];
                    pers.IDPlan = (int)drPersonas["id_plan"];
                }

                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", ex);
                throw ex;
            }

            this.CloseConnection();
            return pers;
        }
        public List<Personas> GetAll()
        {
            List<Personas> personas = new List<Personas>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drPersona = cmdPersonas.ExecuteReader();

                while (drPersona.Read())
                {
                    Personas pers = new Personas();
                    pers.ID = (int)drPersona["id_persona"];
                    pers.Nombre = (string)drPersona["nombre"];
                    pers.Apellido = (string)drPersona["apellido"];
                    pers.Direccion = (string)drPersona["direccion"];
                    pers.Email = (string)drPersona["email"];
                    pers.Telefono = (string)drPersona["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    pers.Legajo = (int)drPersona["legajo"];
                    pers.TipoPersona = (int)drPersona["tipo_persona"];
                    pers.IDPlan = (int)drPersona["id_plan"];

                    personas.Add(pers);
                }

                drPersona.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden recuperar los datos de la persona", ex);
            }
            this.CloseConnection();
            return personas;
        }
        public void Delete(int IDPersona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id");
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDPersona;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Personas persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUpdate = new SqlCommand(
                    "UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, telefono = @telefono, " +
                    "fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan " +
                    "WHERE id_persona = @id_persona", sqlConn
                );

                cmdUpdate.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdUpdate.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdUpdate.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmdUpdate.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmdUpdate.Parameters.Add("@fecha_nac", SqlDbType.VarChar).Value = persona.FechaNacimiento;
                cmdUpdate.Parameters.Add("@legajo", SqlDbType.VarChar).Value = persona.Legajo;
                cmdUpdate.Parameters.Add("@tipo_persona", SqlDbType.VarChar).Value = persona.TipoPersona;
                cmdUpdate.Parameters.Add("@id_plan", SqlDbType.VarChar).Value = persona.IDPlan;

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la persona", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Personas persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdInsert = new SqlCommand(
                    "INSERT INTO personas (nombre, apellido, direccion, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "VALUES (@nombre, @apellido, @direccion, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                    "select @@identity" // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdInsert.Parameters.Add("@nombre", SqlDbType.VarChar).Value = persona.Nombre;
                cmdInsert.Parameters.Add("@apellido", SqlDbType.VarChar).Value = persona.Apellido;
                cmdInsert.Parameters.Add("@direccion", SqlDbType.VarChar).Value = persona.Direccion;
                cmdInsert.Parameters.Add("@telefono", SqlDbType.VarChar).Value = persona.Telefono;
                cmdInsert.Parameters.Add("@fecha_nac", SqlDbType.VarChar).Value = persona.FechaNacimiento;
                cmdInsert.Parameters.Add("@legajo", SqlDbType.VarChar).Value = persona.Legajo;
                cmdInsert.Parameters.Add("@tipo_persona", SqlDbType.VarChar).Value = persona.TipoPersona;
                cmdInsert.Parameters.Add("@id_plan", SqlDbType.VarChar).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar la persona", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Personas persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
        public List<Personas> getAllByType(int type)
        {
            List<Personas> todasLasPersonas = new List<Personas>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona = @type", sqlConn);
                cmdPersonas.Parameters.Add("@type", SqlDbType.Int).Value = type;


                SqlDataReader drPersona = cmdPersonas.ExecuteReader();

                while (drPersona.Read())
                {
                    Personas pers = new Personas();
                    pers.ID = (int)drPersona["id_persona"];
                    pers.Nombre = (string)drPersona["nombre"];
                    pers.Apellido = (string)drPersona["apellido"];
                    pers.Direccion = (string)drPersona["direccion"];
                    pers.Email = (string)drPersona["email"];
                    pers.Telefono = (string)drPersona["telefono"];
                    pers.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    pers.Legajo = (int)drPersona["legajo"];
                    pers.TipoPersona = (int)drPersona["tipo_persona"];
                    pers.IDPlan = (int)drPersona["id_plan"];

                    todasLasPersonas.Add(pers);
                }

                drPersona.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de personas", ex);
                throw ExcepcionManejada;
            }
            // Ya se cerró la conexión dentro de getPermisos()
            //this.CloseConnection();
            return todasLasPersonas;
        }
    }
}
