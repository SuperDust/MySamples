using EFCodeFirst.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCodeFirst.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(t => t.UserId);
            modelBuilder.Entity<Product>().HasKey(t => t.ProductId);
            modelBuilder.Entity<Order>(t =>
            {
                t.HasKey(x => x.OrderId);
                t.HasOne(x => x.Product).WithOne(x => x.Order).HasForeignKey<Order>(x => x.ProductId);
                t.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            });
            modelBuilder.Entity<User>().HasData(new User[] {
                new User{ UserId = 1, UserName = "张三" },
                new User{ UserId = 2, UserName = "李四" },
                new User{ UserId = 3, UserName = "麻五" }
            });
            modelBuilder.Entity<Product>().HasData(new Product[]{
            new Product{ ProductId = 1, ProductName = "烤鸭", ProductNum = 30 },
            new Product{ ProductId = 2, ProductName = "火腿", ProductNum = 40 },
            new Product{ ProductId = 3, ProductName = "啤酒", ProductNum = 50 }
            });
            modelBuilder.Entity<Order>().HasData(new Order[] {
                new Order{ OrderId = 1, ProductId = 1, UserId = 2 },
                new Order{ OrderId = 2, ProductId = 2, UserId = 2 },
                new Order{ OrderId = 3, ProductId = 3, UserId = 2 }
            });
        }
    }
}