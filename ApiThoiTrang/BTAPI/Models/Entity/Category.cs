using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    [Table("Category")]
    public class Category 
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Status { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}