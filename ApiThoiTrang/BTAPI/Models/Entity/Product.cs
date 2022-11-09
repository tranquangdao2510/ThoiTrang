using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Image { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int View { get; set; }
        public int Cate_id { get; set; }
        public int Status { get; set; }

        [ForeignKey("Cate_id")]
        public Category Category { get; set; }
    }
}