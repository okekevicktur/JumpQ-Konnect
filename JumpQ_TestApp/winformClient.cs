using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpQ_TestApp
{
    class winformClient
    {
            
                public int name { get; set; }
                public string email { get; set; }
                public string username { get; set; }
                public string phone { get; set; }
                public int store_branch { get; set; }
                public string api_token { get; set; }

              

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

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Product
    {
        public string name;
        public int price;
        public int cost_price;
        public string barcode;
        public string description;
        public int quantity;
    }

    public class Root2
    {
        public List<Product> products{ get; set; }
    }

}
