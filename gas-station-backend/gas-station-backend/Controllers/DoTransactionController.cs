using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Processes and logs a transaction of gas or store items.
    /// </summary>
    public class DoTransactionController : ApiController
    {
        /// <summary>
        /// Logs one transaction that consists of one or more item.
        /// </summary>
        /// <param name="request">the transaction information</param>
        /// <returns>true on success</returns>
        public bool Post(InternalTransactionPostModel request)
        {
            Transaction.LogTransaction(request);
            return true;
        }

        public class InternalTransactionPostModel
        {
            /// <summary>
            /// The credit card number (or "cash" for a cash transaction).
            /// </summary>
            public string cc { get; set; }
            /// <summary>
            /// The item(s) in this transaction.
            /// </summary>
            public List<InternalItemsModel> items { get; set; }

            /// <summary>
            /// An item from the store, or an "item" of a gas purchase.
            /// </summary>
            public class InternalItemsModel
            {
                /// <summary>
                /// The description of the item or the grade of gas.
                /// </summary>
                public string description { get; set; }
                /// <summary>
                /// The price (including tax) of this item.
                /// </summary>
                public string price { get; set; }
            }
        }
    }
}