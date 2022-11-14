using API.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models.Entity.Admin
{
    public class GroupUser
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Employes> Employes { get; set; }
    }
}