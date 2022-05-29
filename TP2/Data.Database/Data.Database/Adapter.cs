using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


//Esta clase es como el Handler o Scheduler que usábamos en Java, es la que realizará la conexión con la DB y el
//cierre de la misma



namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
