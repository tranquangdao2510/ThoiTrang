using API.Models.Entity;
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
        public DbSet<User> users { get; set; }

        #region db Thời trang
         public DbSet<Size> Sizes { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employes> Employes { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Color> Colors { get; set; }


        #endregion

       

    }
}