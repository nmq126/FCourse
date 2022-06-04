using FCourse.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FCourse.Data
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Level> Levels { get; set; }    
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserSection> UserSections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(c => c.OrderDetails);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<FCourse.Models.Cart> Carts { get; set; }
    }
}