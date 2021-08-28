using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class Order
    {
        public string oid { get; set; }

        public string otime { get; set; }

        public string user_id { get; set; }
        public static int AddOrder(string orderid,string ordertime,string uid)
        {
            return SqlHelper.ExecuteNonQuery($"INSERT INTO [Order](oid ,otime ,user_id) VALUES('{orderid}','{ordertime}','{uid}')");
        }

        public static int DeleteOrder(string orderid)
        {
            return SqlHelper.ExecuteNonQuery($"delete from [Order] where oid = '{orderid}'");
        }

    }
}
