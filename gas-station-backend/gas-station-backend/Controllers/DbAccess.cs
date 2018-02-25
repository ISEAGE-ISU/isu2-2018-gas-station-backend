using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Database access abstraction.
    /// </summary>
    public static class DbAccess
    {
        /// <summary>
        /// The connection string from web.config
        /// </summary>
        static private readonly string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        /// <summary>
        /// Executes a SQL command and ignore any result.
        /// </summary>
        /// <param name="command">the SQL command</param>
        public static void RunCommand(String command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand commandObj = new SqlCommand(command, connection);
            commandObj.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Executes a SQL command and returns the data reader. Note, you should close the data reader
        /// when you are done, but who am I to judge.
        /// </summary>
        /// <param name="command">the SQL command</param>
        /// <returns>a data reader ready to read the result from the commmand</returns>
        public static SqlDataReader RunReader(String command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand commandObj = new SqlCommand(command, connection);
            return commandObj.ExecuteReader();
        }
    }
}