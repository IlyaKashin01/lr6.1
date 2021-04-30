using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace lr6.DAO
{
    public class DAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public SqlConnection sqlConnection = null;
        public void Connect()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public void Disconnect()
        {
            sqlConnection.Close();
        }
    }
}