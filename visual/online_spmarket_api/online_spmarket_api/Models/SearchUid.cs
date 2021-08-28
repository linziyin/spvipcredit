﻿using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class SearchUid
    {
        public string oid { get; set; }

        public string otime { get; set; }

        public string user_id { get; set; }
        public string pid { get; set; }

        public int count { get; set; }

        public static List<SearchUid> GetSearchuidList(string uid)
        {
            DataTable dt = SqlHelper.ExecuteTable("select u.oid,otime,user_id,pid,count from [Order] u join [OrderItem] d on u.oid=d.oid where user_id = uid");
            List<SearchUid> orders = new List<SearchUid>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orders.Add(ToModel(dt.Rows[i]));
            }
            return orders;
        }
        private static SearchUid ToModel(DataRow dr)
        {
            SearchUid order = new SearchUid();
            order.oid = dr["oid"].ToString();
            order.otime = dr["otime"].ToString();
            order.user_id = dr["user_id"].ToString();
            order.pid = dr["pid"].ToString();
            order.count = (int)dr["count"];


            return order;
        }
    }
}
