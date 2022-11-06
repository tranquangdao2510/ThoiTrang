using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public double Total_amount { get; set; }
        public int Payment { get; set; }
        public int Note { get; set; }
        public bool Status { get; set; }
    }
}