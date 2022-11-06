using BTAPI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTAPI.Models.DataModel
{
    public class DbConn : DbContext
    {
        public DbConn() : base("name=ThoiTrang")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbConn, Migrations.Configuration>("ThoiTrang"));
        }
        public DbSet<User> users { get; set; }

        #region db Thời trang
         public DbSet<Size> Size { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Employes> Employes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Color> Color { get; set; }


        #endregion

       

    }
}