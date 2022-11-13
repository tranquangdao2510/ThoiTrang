using API.Models.Entity.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Employes
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên nhân viên")]
        public string Name { get; set; }
        [Display(Name = "Tên email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public int GroupID { get; set; }


        [ForeignKey("GroupID")]
        public virtual GroupUser GroupUsers { get; set; }

    }
}