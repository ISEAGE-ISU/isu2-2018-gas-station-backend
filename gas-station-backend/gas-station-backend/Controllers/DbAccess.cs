using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gas_station_backend.Controllers
{
    public static class DbAccess
    {
        static private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public static void RunCommand(String command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand commandObj = new SqlCommand(command, connection);
            commandObj.ExecuteNonQuery();
            connection.Close();
        }

        public static SqlDataReader RunReader(String command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand commandObj = new SqlCommand(command, connection);
            return commandObj.ExecuteReader();
        }
    }
}