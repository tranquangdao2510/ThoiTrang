using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên loại")]
        public string Name{ get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public ICollection<ProductDetail> ProductDetail { get; set; }
    }
}