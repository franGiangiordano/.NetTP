using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;


//Esta clase es como el Handler o Scheduler que usábamos en Java, es la que realizará la conexión con la DB y el
//cierre de la misma



namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        //Nota: el string que aparece debajo es para conectarnos en los laboratorios de UTN
       //const string consKeyDefaultCnnString = "ConnStringLocal"; 

        //Nota: con este string nos deberia conectar a la DB desde nuestras casas

       const string consKeyDefaultCnnString = "ConnStringLocalCasa";

     //const string consKeyDefaultCnnString = "ConnStringLocalCasa";

        public SqlConnection sqlconn;
        protected void OpenConnection()
        {
            sqlconn = new SqlConnection();

            //Nota: el sqlconn que aparece abajo es para conectarnos en los laboratios de UTN
          //sqlconn.ConnectionString = @"Server=.\SQLEXPRESS;Database=Academia;Integrated Security = false; User = net; Password = net;";

            //Nota: con este sqlconn nos deberia conectar a la DB desde nuestras casas
         sqlconn.ConnectionString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            //sqlconn.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=SSPI;";

            //sqlconn.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=SSPI;";
            sqlconn.Open();


            //Data Source=.;Initial Catalog=Academia;Integrated Security=True
        }

        protected void CloseConnection()
        {
            sqlconn.Close();
            sqlconn = null;

        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
