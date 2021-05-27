using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpQ_Task
{
    class ProductsModel
    {

    }
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
        public string store_branch { get; set; }
        public string api_token { get; set; }
    }
    public class Root
    {
        public List<string> message { get; set; }
        public User user { get; set; }
    }
    class APIRoute
    {
        public string LoginEndpoint = "https://myjumpq.net/api/staff/login";
        public string AddProductEndpoint = "https://myjumpq.net/api/staff/add_products";
    }

    public class Product
    {
        public string name;
        public double price;
        public double cost_price;
        public string barcode;
        public string description;
        public int quantity;
    }

    public class Root2
        {
            public List<Product> products { get; set; }
        }
}