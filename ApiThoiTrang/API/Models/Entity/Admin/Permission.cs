using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity.Admin
{
    public class Permission
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BusinessId { get; set; }
        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
        public bool Status { get; set; }

        public ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}