using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Image { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int View { get; set; }
        public int Cate_id { get; set; }
        public int Status { get; set; }
    }
}