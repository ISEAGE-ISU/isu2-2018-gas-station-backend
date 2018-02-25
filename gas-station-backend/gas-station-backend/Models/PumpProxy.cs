using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static void AuthorizeDispense(int pump, double gallons, int grade)
        {
            // TODO
        }
    }
}