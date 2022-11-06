using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTAPI.Models.DataModel
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "vui lòng nhập tên")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "vui lòng nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "vui lòng nhập Pas")]
        public string Password { get; set; }
        [Required(ErrorMessage = "vui lòng nhập SDT")]
        public string Phone { get; set; }
        public string Avatar { get; set; }
      
        [Required(ErrorMessage = "vui lòng nhập Ngày sinh")]
        public DateTime Birthday { get; set; }
        public bool status { get; set; }
    }
}