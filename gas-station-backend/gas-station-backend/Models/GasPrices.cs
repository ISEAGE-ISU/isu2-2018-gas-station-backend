using gas_station_backend.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace gas_station_backend.Models
{
    /// <summary>
    /// Gas prices controller class. (Why is it in models?  I don't know.)
    /// </summary>
    public class GasPrices
    {
        /// <summary>
        /// Gets the current gas prices per gallon from the database.
        /// </summary>
        /// <returns>an array of gas prices in the order of regular, plus, premium</returns>
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

        /// <summary>
        /// Sets a single gas price.
        /// </summary>
        /// <param name="grade">the grade, where 0=>regular,1=>plus,2=>premium</param>
        /// <param name="val">the price per gallon as a decimal number</param>
        public static void Set(string grade, string val)
        {
            String command = String.Format("UPDATE GasPrices SET price = {0} WHERE GRADE = {1}", val, grade);
            DbAccess.RunCommand(command);
        }
    }
}