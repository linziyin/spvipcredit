using online_spmarket_api.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace online_spmarket_api.Models
{
    public class Products
    {
        public string pid { get; set; }
        public string pname { get; set; }
        public string pimgurl { get; set; }
        public double pcredit { get; set; }
        public string pbrand { get; set; }
        public string parea { get; set; }
        public string psort { get; set; }
       // public string pchecked { get; set; }



        public static List<Products> GetProductList()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM [Product] where pcredit<0");
            List<Products> products = new List<Products>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(ToModel(dt.Rows[i]));
            }
            return products;
        }

      

        public static List<Products> GetProductListAll()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT * FROM [Product]");
            List<Products> products = new List<Products>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products.Add(ToModel(dt.Rows[i]));
            }
            return products;
        }
        private static Products ToModel(DataRow dr)
        {
            Products product = new Products();
            product.pid = dr["pid"].ToString();
            product.pname = dr["pname"].ToString();
            product.pimgurl = dr["pimgurl"].ToString();
            product.pcredit = (double)dr["pcredit"];
            product.pbrand = dr["pbrand"].ToString();
            product.parea = dr["parea"].ToString();
            product.psort = dr["psort"].ToString();
           // product.pchecked = dr["pchecked"].ToString();

            return product;
        }

        public static int DeleteProductItem(string productid)
        {
            return SqlHelper.ExecuteNonQuery($"delete from [Product] where pid='{productid}'");
        }

        public static int AddGoods(string pid, string pname, string pimgurl, double pcredit, string pbrand, string parea, string psort)
        {
            string[] urls = pimgurl.Split('\\');
            string url = "upload/" + urls[urls.Length - 1];
            return SqlHelper.ExecuteNonQuery($"INSERT INTO [Product](pid, pname, pimgurl, pcredit, pbrand, parea, psort) VALUES('{pid}','{pname}','{url}','{pcredit}','{pbrand}','{parea}','{psort}')");
        }



    }
}
