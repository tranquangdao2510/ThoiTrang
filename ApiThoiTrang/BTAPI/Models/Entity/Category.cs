using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Tên loại")]
        public string Name { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}