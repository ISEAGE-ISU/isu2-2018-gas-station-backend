using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Gets prepay authorization for pumps. This is when a customer pays for gas
    /// at the point of sale. The pump requests the status from the backend.
    /// </summary>
    public class GetPrepayStatusController : ApiController
    {
        /// <summary>
        /// Consumes a prepay authorization for a specific pump. THIS WILL RESET THE
        /// PREPAY STATUS FOR THE PUMP.
        /// </summary>
        /// <param name="pump">the pump number to check for an authorization</param>
        /// <returns>how much the customer prepaid</returns>
        public InternalPrepayGetModel Get(string pump)
        {
            return PumpProxy.GetAuthorization(pump);
        }
        
        /// <summary>
        /// A model for sending a gas authorization result to a pump.
        /// </summary>
        public class InternalPrepayGetModel
        {
            /// <summary>
            /// Boolean of whether a transaction has been prepaid. 0=false,1=true.
            /// </summary>
            public int prepay { get; set; }
            /// <summary>
            /// The amount of gas that has been authorized, in dollars. Rounded to the nearest
            /// whole number to be an int. If prepay==0, dollars=0.
            /// </summary>
            public int dollars { get; set; }
        }
    }
}