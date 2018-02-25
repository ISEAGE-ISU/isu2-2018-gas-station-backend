using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Sets a single grade's price per gallon.
    /// </summary>
    public class SetGasPriceController : ApiController
    {
        /// <summary>
        /// Updates the price per gallon of one grade of gasoline.
        /// </summary>
        /// <param name="priceRequest">The desired price.</param>
        /// <returns>true on success</returns>
        public bool Post(InternalPricePostModel priceRequest)
        {
            try
            {
                GasPrices.Set(priceRequest.grade, priceRequest.price);
            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Class to take in the price request.
        /// </summary>
        public class InternalPricePostModel
        {
            /// <summary>
            /// The grade of gas. Must be 0-2.
            /// </summary>
            public string grade { get; set; }
            /// <summary>
            /// The price per gallon of the specified grade.
            /// </summary>
            public string price { get; set; }
        }
    }
}