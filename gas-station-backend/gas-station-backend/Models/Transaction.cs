﻿using gas_station_backend.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static gas_station_backend.Controllers.DoTransactionController;
using static gas_station_backend.Controllers.GetTransactionsController;

namespace gas_station_backend.Models
{
    public class Transaction
    {
        public static void LogTransaction(InternalTransactionPostModel t)
        {
            decimal total = t.items.Sum(i => decimal.Parse(i.price));
            String command = String.Format("INSERT INTO Transactions (time, cc, total) VALUES (GETDATE(), '{0}', {1}); SELECT @@IDENTITY AS txid", t.cc, total);
            SqlDataReader reader = DbAccess.RunReader(command);
            reader.Read();
            int txid = decimal.ToInt32((decimal)reader["txid"]);
            reader.Close();

            for (int i = 0; i < t.items.Count; i++)
            {
                command = String.Format("INSERT INTO TransactionLineItems VALUES ({0}, {1}, '{2}', {3})", txid, i, t.items[i].description, t.items[i].price);
                DbAccess.RunCommand(command);
            }
        }

        public static InternalTransactionGetModel[] GetTransactions()
        {
            List<InternalTransactionGetModel> o = new List<InternalTransactionGetModel>();
            String command = "SELECT * FROM Transactions LEFT JOIN TransactionLineItems ON Transactions.id = TransactionLineItems.txid WHERE line = 0";
            SqlDataReader reader = DbAccess.RunReader(command);

            while (reader.Read())
            {
                o.Add(new InternalTransactionGetModel()
                {
                    txid = (int)reader["id"],
                    time = (DateTime)reader["time"],
                    cc = (string)reader["cc"],
                    total = (decimal)reader["total"],
                    firstItem = (string)reader["descrip"]
                });
            }
            reader.Close();

            return o.ToArray();
        }
    }
}