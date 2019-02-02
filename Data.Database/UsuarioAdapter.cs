using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Clave = (string)drUsuarios["clave"];
                    //usr.IDPersona = (int)drUsuarios["id_persona"];
                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IDPersona = (int)drUsuarios["id_persona"];
                    }

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de usuarios", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Clave = (string)drUsuarios["clave"];
                    //usr.IDPersona = (int)drUsuarios["id_persona"];
                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IDPersona = (int)drUsuarios["id_persona"];
                    }
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }

            this.CloseConnection();
            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete from usuarios where id_usuario = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                    "WHERE id_usuario = @id", sqlConn
                );

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.EMail;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el usuario", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }
        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                    "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                    "select @@identity", sqlConn // para recuperar el ID que se asigna en SQL automáticamente
                );

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.EMail;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el usuario", ex);
                throw ExcepcionManejada;
            }
            this.CloseConnection();
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }
        public Business.Entities.Usuario GetOneByUserAndPassword(string username, string pass)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @usuario and clave = @pass", sqlConn);
                cmdUsuarios.Parameters.Add("@usuario", SqlDbType.VarChar).Value = username;
                cmdUsuarios.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Clave = (string)drUsuarios["clave"];
                    //usr.IDPersona = (int)drUsuarios["id_persona"];
                    if (!drUsuarios.IsDBNull(8))
                    {
                        usr.IDPersona = (int)drUsuarios["id_persona"];
                    }
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }

            this.CloseConnection();
            return usr;
        }
        public Personas GetPersona(int userID)
        {
            PersonaAdapter persAdapter = new PersonaAdapter();
            return persAdapter.GetOne(this.GetOne(userID).IDPersona);
        }
        public int getPermisos(int userID)
        {
            Business.Entities.Personas pers = this.GetPersona(userID);
            return pers.TipoPersona;
        }
    }
}
