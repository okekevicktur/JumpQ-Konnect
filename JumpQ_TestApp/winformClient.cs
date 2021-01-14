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

                //public string Lastname { get; set; }
                //public string phone { get; set; }
                //public int Password { get; set; }
        
        
    //    "name": "Joel Johnson",
    //"email": "joel.marcus@gmail.com",
    //"username": "joel12",
    //"phone": "07011903917",
    //"store_branch": "Infinix Phone Company",
    //"api_token": "pCj5w66Z6p0octOjpT0rrEOmIUfKqbhTc6NmdqPIYBHO96spmSreZXKd3hOH"
       

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

    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public int cost_price { get; set; }
        public string barcode { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
    }

    public class RootProduct
    {
        public List<Product> products { get; set; }
    }

}
