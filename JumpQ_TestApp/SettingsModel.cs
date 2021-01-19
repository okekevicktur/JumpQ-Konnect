using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpQ_TestApp
{
    class SettingsModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }

    class APIRoute
    {
        public string LoginEndpoint = "https://myjumpq.net/api/staff/login";
        public string AddProductEndpoint = "https://myjumpq.net/api/staff/add_products";
    }

    class SalesRecieptModel
    {
        public string CustomerID { get; set; }
        public string Comments { get; set; }
        public string CashierName { get; set; }

        public string ItemName { get; set; }
        public string SalesRecieptType { get; set; }

        public int ItemQuantity { get; set; }
        public int ItemPrice { get; set; }
        public int AmountTendered { get; set; }

        public string ItemQRcode { get; set; }
   
    }
}
