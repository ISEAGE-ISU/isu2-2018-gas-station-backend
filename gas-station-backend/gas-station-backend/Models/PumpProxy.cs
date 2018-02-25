using gas_station_backend.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static gas_station_backend.Controllers.GetPrepayStatusController;

namespace gas_station_backend.Models
{
    /// <summary>
    /// This class is to relay communication between the point of sale computer and the pumps.
    /// </summary>
    public class PumpProxy
    {
        /// <summary>
        /// Relays a message to a pump that it is allowed to pump a specific amount of gas.
        /// </summary>
        /// <param name="pump">The pump number to dispense from</param>
        /// <param name="gallons">The amount of gas to allow to be dispensed</param>
        /// <param name="grade">The grade of gas that's allowed to dispense. 0=regular, 1=plus, 2=premium</param>
        public static void AuthorizeDispense(string pump, string gallons, string grade)
        {
            // Delete any pending authorization.
            string command = string.Format("DELETE FROM TransactionAuthorizations WHERE pump={0}", pump);
            DbAccess.RunCommand(command);

            // Add authorization
            command = string.Format("INSERT INTO TransactionAuthorizations VALUES ({0}, {1}, {2})", pump, gallons, grade);
            DbAccess.RunCommand(command);
        }

        /// <summary>
        /// Gets the authorization status of a pump and DELETES IT FROM THE DATABASE.
        /// </summary>
        /// <param name="pump">the pump number to get authorization for</param>
        /// <returns>the authorization status of the pump</returns>
        public static InternalPrepayGetModel GetAuthorization(string pump)
        {
            // Get any authorizations.
            InternalPrepayGetModel o = new InternalPrepayGetModel();
            string command = string.Format("SELECT CAST(ROUND(gallons * price, 0) as int) AS dollars FROM TransactionAuthorizations " +
                "LEFT JOIN GasPrices ON TransactionAuthorizations.grade=GasPrices.grade WHERE pump={0}", pump);
            SqlDataReader reader = DbAccess.RunReader(command);
            if (reader.Read())
            {
                o.prepay = 1;
                o.dollars = (int)reader["dollars"];
            }

            // Delete the consumed authorization
            command = string.Format("DELETE FROM TransactionAuthorizations WHERE pump={0}", pump);
            DbAccess.RunCommand(command);
            return o;
        }
    }
}