using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên khách hàng")]
        public string Name { get; set; }
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime Brithday { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Pasword { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}