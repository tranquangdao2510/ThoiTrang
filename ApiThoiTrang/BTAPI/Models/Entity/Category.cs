using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTAPI.Models.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Status { get; set; }
        //public ICollection<BankAccount> BankAccounts { get; set; }
    }
}