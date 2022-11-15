using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên tiêu đề")]
        public string Title { get; set; }
        public int Image { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Giá cả")]
        public int Price { get; set; }
        public int View { get; set; }
        public int Cate_id { get; set; }
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [ForeignKey("Cate_id")]
        public Category Category { get; set; }
        public ICollection<ProductDetail> ProductDetail { get; set; }
    }
}