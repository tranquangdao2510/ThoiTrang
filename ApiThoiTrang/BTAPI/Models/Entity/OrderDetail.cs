using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_detail_Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool Status{ get; set; }
    }
}