using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public double Total_amount { get; set; }
        public int Payment { get; set; }
        public int Note { get; set; }
        public bool Status { get; set; }

        [ForeignKey("Customer_id")]
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }
       
        
    }
}