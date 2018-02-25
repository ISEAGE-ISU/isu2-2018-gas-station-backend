using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static gas_station_backend.Controllers.DoTransactionController;

namespace gas_station_backend.Controllers
{
    public class GetTransactionsController : ApiController
    {
        public InternalTransactionGetModel[] Get()
        {
            return Transaction.GetTransactions();
        }

        public class InternalTransactionGetModel
        {
            /// <summary>
            /// The transaction ID.
            /// </summary>
            public int txid { get; set; }
            /// <summary>
            /// The time the transactiont took place.
            /// </summary>
            public DateTime time { get; set; }
            /// <summary>
            /// The credit card used on the transaction, or "cash" if cash.
            /// </summary>
            public string cc { get; set; }
            /// <summary>
            /// The grand total of the transaction.
            /// </summary>
            public decimal total { get; set; }
            /// <summary>
            /// The first item from the items purchased in the transaction.
            /// </summary>
            public string firstItem { get; set; }
        }
    }
}