using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class OrderUnion
    {
        public string oid { get; set; }

        public string otime { get; set; }

        public string user_id { get; set; }
        public string pid { get; set; }
        public string pimgurl { get; set; }
        public string pname { get; set; }
        public double pcredit { get; set; }
        public int count { get; set; }
        public double pnewCredit { get; set; }
        public static List<OrderUnion> GetOrderList()
        {
           // DataTable dt = SqlHelper.ExecuteTable("select u.oid,otime,user_id,pid,count from [Order] u join [OrderItem] d on u.oid=d.oid ");
            DataTable dt = SqlHelper.ExecuteTable("select u.oid,otime,user_id,p.pid,pimgurl,pname,pcredit,count,-count*pcredit as pnewCredit from [Order] u join [OrderItem] d  on u.oid=d.oid join [Product] p on p.pid=d.pid ");

            List<OrderUnion> orders = new List<OrderUnion>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orders.Add(ToModel(dt.Rows[i]));
            }
            return orders;
        }
        private static OrderUnion ToModel(DataRow dr)
        {
            OrderUnion order = new OrderUnion();
            order.oid = dr["oid"].ToString();
            order.otime = dr["otime"].ToString();
            order.user_id = dr["user_id"].ToString();
            order.pid = dr["pid"].ToString();
            order.pimgurl = dr["pimgurl"].ToString();
            order.pname = dr["pname"].ToString();
            order.pcredit = (double)dr["pcredit"];
            order.count = (int)dr["count"];
            order.pnewCredit = (double)dr["pnewCredit"];
            return order;
        }


    }
}
