using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models.Entity.Admin
{
    public class Business
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}