using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Gets the current gas prices for this gas station.
    /// </summary>
    public class GetGasPricesController : ApiController
    {
        /// <summary>
        /// Gets all the current gas prices.
        /// </summary>
        /// <returns>An array of the cost of each gas type per gallon.
        /// [regular, plus, premium]</returns>
        public double[] Get()
        {
            return GasPrices.Get();
        }
    }
}