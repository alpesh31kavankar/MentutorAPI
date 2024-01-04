using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace PrismAPI.DAL
{
    public class DbConnection
    {
        public readonly string connectionString = string.Empty;

        public DbConnection()
        {
            connectionString = ConfigurationManager.ConnectionStrings["OAuthContext"].ToString();
        }

        public SqlConnection OpenDbConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }
    }
}