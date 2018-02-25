using gas_station_backend.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gas_station_backend.Models
{
    public class GasPrices
    {
        public static double[] Get()
        {
            double[] prices = new double[3];
            String command = "SELECT * FROM GasPrices";
            SqlDataReader reader = DbAccess.RunReader(command);
            while (reader.Read())
            {
                prices[(int)reader["grade"]] = decimal.ToDouble((decimal)reader["price"]);
            }
            reader.Close();
            return prices;
        }

        public static void Set(string grade, string val)
        {
            String command = String.Format("UPDATE GasPrices SET price = {0} WHERE GRADE = {1}", val, grade);
            DbAccess.RunCommand(command);
        }
    }
}