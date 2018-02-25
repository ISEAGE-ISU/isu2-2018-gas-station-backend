using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Authorizes a pump to dispense gas that has been prepaid at the point of sale system.
    /// </summary>
    public class DispenseGasController : ApiController
    {
        /// <summary>
        /// Authorizes a pump to dispense gas.
        /// </summary>
        /// <returns>true on success</returns>
        public bool Post(InternalDispensePostModel request)
        {
            try
            {
                PumpProxy.AuthorizeDispense(request.pump, request.gallons, request.grade);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// A model to represent the request parameters of a dispense request.
        /// </summary>
        public class InternalDispensePostModel
        {
            /// <summary>
            /// The pump number to dispense from
            /// </summary>
            public string pump { get; set; }
            /// <summary>
            /// The amount of gas to dispense
            /// </summary>
            public string gallons { get; set; }
            /// <summary>
            /// The grade of gas to dispense.  0=regular, 1=plus, 2=premium
            /// </summary>
            public string grade { get; set; }
        }
    }
}