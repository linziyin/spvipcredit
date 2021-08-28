using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Common
{
    public class SqlHelper
    {
        public static string Constr { get; set; }
        public static DataTable ExecuteTable(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }
        public static DataTable ExecuteTable2(string cmdText2)
        {
            using (SqlConnection con2 = new SqlConnection(Constr))
            {
                con2.Open();
                SqlCommand cmd2 = new SqlCommand(cmdText2, con2);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                sda2.Fill(ds2);
                return ds2.Tables[0];
            }
        }
        public static int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdText, con);
                int rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    throw new Exception("数据库执行错误");
                }
                return rows;
            }
        }
    }
}
