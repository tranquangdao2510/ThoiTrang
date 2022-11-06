using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Size_id { get; set; }
        public int Color_id { get; set; }
        public string Description { get; set; }
        public string Image_detail { get; set; }
        public bool Status { get; set; }
    }
}