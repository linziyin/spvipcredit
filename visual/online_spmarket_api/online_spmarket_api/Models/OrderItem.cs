using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class OrderItem
    {
        public string pid { get; set; }

        public string oid { get; set; }

        public int count { get; set; }
        public static int AddOrderItem(string productid, string orderid, int count)
        {
            return SqlHelper.ExecuteNonQuery($"INSERT INTO [OrderItem](pid ,oid ,count) VALUES('{productid}','{orderid}','{count}')");
        }

        public static int DeleteOrderItem(string productid, string orderid)
        {
            return SqlHelper.ExecuteNonQuery($"delete from [OrderItem] where pid='{productid}' and oid='{orderid}'");
        }

        public static int DeleteOrderItemAll(string orderid)
        {
            return SqlHelper.ExecuteNonQuery($"delete from [OrderItem] where oid='{orderid}'");
        }
    }
}
