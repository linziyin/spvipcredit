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
    public class ProductsController : ControllerBase
    {
        public List<Products> GetProducts()
        {
            List<Products> productList = Products.GetProductList();
            return productList;
        }

        public List<Products> GetProductListAll()
        {
            List<Products> productList = Products.GetProductListAll();
            return productList;
        }

        public List<Products> GetProductById(string pid)
        {
            List<Products> productList = Products.GetProductList();
            return productList.FindAll(m => m.pid == pid);
        }
        public List<Products> GetProductById1(string pid)
        {
            List<Products> productList = Products.GetProductListAll();
            return productList.FindAll(m => m.pid == pid);
        }

        public Products GetProductAllById(string pid)
        {
            List<Products> productListAll = Products.GetProductListAll();
            return productListAll.Find(m => m.pid == pid);
        }

        public int DeleteProductItem(string productid)
        {
            int rows = Products.DeleteProductItem(productid);
            return rows;
        }

        public int AddGoods(string pid, string pname, string pimgurl, double pcredit, string pbrand, string parea, string psort)
        {
            int rows = Products.AddGoods(pid, pname, pimgurl, pcredit, pbrand, parea, psort);
            return rows;
        }


    }
}
