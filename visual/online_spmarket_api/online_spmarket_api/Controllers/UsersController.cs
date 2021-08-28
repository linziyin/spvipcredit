using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using online_spmarket_api.Models;

namespace online_spmarket_api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public List<Users> GetUsers()
        {
            List<Users> userList = Users.GetUserList();
            return userList;
        }
        public Users GetUserByUId(string uid)
        {
            List<Users> userList = Users.GetUserList();
            return userList.Find(m => m.uid == uid);
        }
        public int AddOrder(string orderid, string ordertime, string uid)
        {
            int rows = Order.AddOrder(orderid,ordertime,uid);
            return rows;
        }
        public int AddOrderItem(string productid, string orderid, int count)
        {
            int rows = OrderItem.AddOrderItem(productid, orderid, count);
            return rows;
        }

        public int DeleteOrder(string orderid)
        {
            int rows = Order.DeleteOrder(orderid);
            return rows;
        }
        public int DeleteOrderItem(string productid, string orderid)
        {
            int rows = OrderItem.DeleteOrderItem(productid, orderid);
            return rows;
        }

        public int DeleteOrderItemAll (string orderid)
        {
            int rows = OrderItem.DeleteOrderItemAll(orderid);
            return rows;
        }


        public int ChangeCredit(double usercredit, string userid)
        {
            int rows = Users.ChangeCredit(usercredit, userid);
            return rows;
        }
    }
}
