using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace POSX.Utilities
{
    //public class DBConnection
    // {
    //public SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["POSX_ConnectionString"].ConnectionString);


    public static class DBConnection
    {
        public static string _connectionString;

        public static string GetConnectionString()
        {


            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["POSX_ConnectionString"].ConnectionString;
            }

            return _connectionString;
        }
    }
    
}