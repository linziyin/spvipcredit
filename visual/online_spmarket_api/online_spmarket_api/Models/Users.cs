using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class Users
    {
        public string uid { get; set; }
        public string pwd { get; set; }
        public string type { get; set; }
        public double ucredit { get; set; }


        public static List<Users> GetUserList()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM [User]");
            List<Users> users = new List<Users>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                users.Add(ToModel(dt.Rows[i]));

            }
            return users;

        }
       
        private static Users ToModel(DataRow dr)
        {
            Users user = new Users();
            user.uid = dr["uid"].ToString();
            user.pwd = dr["pwd"].ToString();
            user.type = dr["type"].ToString();
            user.ucredit = (double)dr["ucredit"];


            return user;
        }

        public static int ChangeCredit(double usercredit, string userid)
        {
            return SqlHelper.ExecuteNonQuery($"update [User] set ucredit='{usercredit}' where uid='{userid}'");
        }

        

    }



}
