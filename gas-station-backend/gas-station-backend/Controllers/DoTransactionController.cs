using gas_station_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    public class DoTransactionController : ApiController
    {
        public bool Post(InternalTransactionPostModel request)
        {
            try
            {
                Transaction.LogTransaction(request);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public class InternalTransactionPostModel
        {
            public string cc { get; set; }
            public List<InternalItemsModel> items { get; set; }

            public class InternalItemsModel
            {
                public string description { get; set; }
                public string price { get; set; }
            }
        }
    }
}