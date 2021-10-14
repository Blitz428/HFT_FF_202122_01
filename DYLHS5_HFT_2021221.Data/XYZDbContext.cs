using DYLHS5_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DYLHS5_HFT_2021221.Data
{
    public class XYZDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public XYZDbContext()
        {
            Database.EnsureCreated();
        }

        public XYZDbContext(DbContextOptions<XYZDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");

            }


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(order => order.Product)
                    .WithMany(product => product.Orders)
                    .HasForeignKey(Order => Order.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(product => product.Brand)
                    .WithMany(brand => brand.Products)
                    .HasForeignKey(product => product.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //BRANDS
            Brand dorko = new Brand() {BrandId = 1, BrandName = "Dorko" };
            Brand adidas = new Brand() { BrandId = 2, BrandName = "Adidas" };
            Brand nike = new Brand() { BrandId = 3, BrandName = "Nike" };
            Brand converse = new Brand() { BrandId = 4, BrandName = "Converse" };
            Brand vans = new Brand() { BrandId = 5, BrandName = "Vans" };


            //PRODUCTS
            Product dorko1 = new Product() { ProductId = 1, BrandID = dorko.BrandId, ProductName = "BOUNCE", Color = "BROWN", Size = 41, BasePrice = 24999 };
            Product dorko2 = new Product() { ProductId = 2, BrandID = dorko.BrandId, ProductName = "CARBONITE", Color = "BLACK", Size = 42, BasePrice = 24999 };

            Product adidas1 = new Product() { ProductId = 3, BrandID = adidas.BrandId, ProductName = "ORIGINALS CONTINENTAL 80 STRIPES", Color = "BLACK", Size = 42, BasePrice = 29999 };
            Product adidas2 = new Product() { ProductId = 4, BrandID = adidas.BrandId, ProductName = "PERFORMANCE HOOPS MID 2.0 K", Color = "BLACK", Size = 40, BasePrice = 14999 };

            Product nike1 = new Product() { ProductId = 5, BrandID = nike.BrandId, ProductName = "AIR PRESTO", Color = "ORANGE", Size = 40, BasePrice = 44999 };
            Product nike2 = new Product() { ProductId = 6, BrandID = nike.BrandId, ProductName = "REVOLUTION 5", Color = "GREY", Size = 45, BasePrice = 19999 };

            Product converse1 = new Product() { ProductId = 7, BrandID = converse.BrandId, ProductName = "RIVAL", Color = "GREY", Size = 41, BasePrice = 24999 };
            Product converse2 = new Product() { ProductId = 8, BrandID = converse.BrandId, ProductName = "COURTLANDT", Color = "GREY", Size = 44, BasePrice = 9999 };

            Product vans1 = new Product() { ProductId = 9, BrandID = vans.BrandId, ProductName = "OLD SKOOL", Color = "BLUE", Size = 41, BasePrice = 29999 };
            Product vans2 = new Product() { ProductId = 10, BrandID = vans.BrandId, ProductName = "ULTRARANGE EXO", Color = "BLACK", Size = 40, BasePrice = 39999 };


            //ORDERS
            Order order1 = new Order() { OrderId = 1, OrderTime = DateTime.Now, Product = dorko1 };
            Order order2 = new Order() { OrderId = 2, OrderTime = DateTime.Now, Product = dorko2 };
            Order order3 = new Order() { OrderId = 3, OrderTime = DateTime.Now, Product = adidas1 };
            Order order4 = new Order() { OrderId = 4, OrderTime = DateTime.Now, Product = adidas2 };
            Order order5 = new Order() { OrderId = 5, OrderTime = DateTime.Now, Product = nike1 };
            Order order6 = new Order() { OrderId = 6, OrderTime = DateTime.Now, Product = nike2 };
            Order order7 = new Order() { OrderId = 7, OrderTime = DateTime.Now, Product = converse1 };
            Order order8 = new Order() { OrderId = 8, OrderTime = DateTime.Now, Product = converse2 };
            Order order9 = new Order() { OrderId = 9, OrderTime = DateTime.Now, Product = vans1 };
            Order order10 = new Order() { OrderId = 10, OrderTime = DateTime.Now, Product = vans2 };

            modelBuilder.Entity<Brand>().HasData(dorko, nike, adidas, converse, vans);
            modelBuilder.Entity<Product>().HasData(dorko1,dorko2, nike1, nike2, adidas1, adidas2, converse1, converse2, vans1, vans2);
            modelBuilder.Entity<Order>().HasData(order1,order2,order3,order4,order5,order6,order7,order8,order9,order10);
        }
    }
}
