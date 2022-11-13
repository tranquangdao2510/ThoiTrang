using API.Models.Entity;
using API.Models.Entity.Admin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Models.DataModel
{
    public class DbConn : DbContext
    {
        public DbConn() : base("name=ThoiTrang")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbConn, Migrations.Configuration>("ThoiTrang"));
        }
       // public DbSet<User> users { get; set; }

        #region db Thời trang
         public DbSet<Size> Size { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Employes> Employe { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Color> Color { get; set; }

        #endregion
        public DbSet<Business> Business { get; set; }
        public DbSet<GroupPermission> GroupPermission { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
        public DbSet<Permission> Permission { get; set; }



    }
}