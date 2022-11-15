using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity.Admin
{
    public class GroupPermission
    {
        [Key]
        [Column(Order = 0)]
        public int GroupId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string PermissionId { get; set; }

        [ForeignKey("GroupId")]
        public GroupUser groupUser { get; set; }
        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }
    }
}