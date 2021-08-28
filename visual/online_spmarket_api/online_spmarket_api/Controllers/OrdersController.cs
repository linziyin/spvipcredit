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
    public class OrdersController : ControllerBase
    {
        public List<OrderUnion> GetOrders()
        {
            List<OrderUnion> orderList = OrderUnion.GetOrderList();
            return orderList;
        }
        public List<OrderUnion> GetOrderByUid(string uid)
        {
            List<OrderUnion> orderList = OrderUnion.GetOrderList();
            return orderList.FindAll(m => m.user_id == uid);
        }

        public List<OrderUnion> GetOrderByOid(string oid)
        {
            List<OrderUnion> orderList = OrderUnion.GetOrderList();
            return orderList.FindAll(m => m.oid == oid);
        }

    }
}
