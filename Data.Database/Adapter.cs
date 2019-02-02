using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        private SqlConnection _sqlConn;
        public SqlConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }
        protected void OpenConnection()
        {
            //string cs = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            string cs = "Server=localhost;Database=Academia; User=net; Password=net;";
            this.sqlConn = new SqlConnection(cs);
            try
            {
                this.sqlConn.Open();
            }
            catch(Exception e)
            {
                throw (e);
            }
        }

        protected void CloseConnection()
        {
            this.sqlConn.Close();
            this.sqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringLocal";
    }
}
