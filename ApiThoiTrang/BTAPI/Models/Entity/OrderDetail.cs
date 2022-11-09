using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_detail_Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool Status{ get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }

        [ForeignKey("Product_detail_Id")]
        public ProductDetail ProductDetail { get; set; }
    }
}