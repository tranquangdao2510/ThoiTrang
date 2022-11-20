using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Size_id { get; set; }
        public int Color_id { get; set; }
        public string Description { get; set; }
        public string Image_detail { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Product_id")]
        public Product Product { get; set; }
        [ForeignKey("Size_id")]
        public Size Size { get; set; }
        [ForeignKey("Color_id")]
        public Color Color { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

    }
}