using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Brithday { get; set; }
        public string Email { get; set; }
        public string Pasword { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}