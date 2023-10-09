using System;
using System.IO;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BussinessObject.DataAccess
{
    public partial class FUFlowerBouquetManagementContext :     DbContext
    {
        public FUFlowerBouquetManagementContext()
        {
        }

        public FUFlowerBouquetManagementContext(DbContextOptions<FUFlowerBouquetManagementContext> options)
            : base(options)
        {
        }

        public Customer getDefaultAccounts()
        {
            var admin = new Customer();
            IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

            admin.CustomerName = "ADMIN";
            admin.Email = config["Credentials:Email"];
            admin.Password = config["Credentials:Password"];

            return admin;

        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<FlowerBouquet> FlowerBouquets { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                 .HasKey(od => new { od.OrderId, od.FlowerBouquetId });
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Category>().HasData(
     new Category
     {
         CategoryId = 1,
         CategoryName = "Category 1",
         CategoryDescription = "Category 1 Description"
     },
     new Category
     {
         CategoryId = 2,
         CategoryName = "Category 2",
         CategoryDescription = "Category 2 Description"
     }
     // Add more categories as needed
 );


            modelBuilder.Entity<Customer>().HasData(
     new Customer
     {
         CustomerId = 1,
         Email = "customer1@example.com",
         CustomerName = "Customer 1",
         City = "City 1",
         Country = "Country 1",
         Password = "password1",
         Birthday = DateTime.Parse("1990-01-01")
     },
     new Customer
     {
         CustomerId = 2,
         Email = "customer2@example.com",
         CustomerName = "Customer 2",
         City = "City 2",
         Country = "Country 2",
         Password = "password2",
         Birthday = DateTime.Parse("1990-02-02")
     }
     // Add more customers as needed
 );


            modelBuilder.Entity<FlowerBouquet>().HasData(
      new FlowerBouquet
      {
          FlowerBouquetId = 1,
          CategoryId = 1,
          FlowerBouquetName = "Flower Bouquet 1",
          Description = "Flower Bouquet 1 Description",
          UnitPrice = 10.99m,
          UnitsInStock = 50,
          FlowerBouquetStatus = 1,
          SupplierId = 1
      },
      new FlowerBouquet
      {
          FlowerBouquetId = 2,
          CategoryId = 2,
          FlowerBouquetName = "Flower Bouquet 2",
          Description = "Flower Bouquet 2 Description",
          UnitPrice = 12.99m,
          UnitsInStock = 30,
          FlowerBouquetStatus = 1,
          SupplierId = 2
      }
      // Add more flower bouquets as needed
  );


            modelBuilder.Entity<Order>().HasData(
      new Order
      {
          OrderId = 1,
          CustomerId = 1,
          OrderDate = DateTime.Now,
          ShippedDate = DateTime.Now.AddDays(1),
          Total = 100.00m,
          OrderStatus = "Completed"
      },
      new Order
      {
          OrderId = 2,
          CustomerId = 2,
          OrderDate = DateTime.Now,
          ShippedDate = DateTime.Now.AddDays(2),
          Total = 150.00m,
          OrderStatus = "Completed"
      }
      // Add more orders as needed
  );


            modelBuilder.Entity<OrderDetail>().HasData(
       new OrderDetail
       {
           OrderId = 1,
           FlowerBouquetId = 1,
           UnitPrice = 10.99m,
           Quantity = 5
       },
       new OrderDetail
       {
           OrderId = 1,
           FlowerBouquetId = 2,
           UnitPrice = 12.99m,
           Quantity = 3
       }
       // Add more order details as needed
   );


            modelBuilder.Entity<Supplier>().HasData(
     new Supplier
     {
         SupplierId = 1,
         SupplierName = "Supplier 1",
         SupplierAddress = "Supplier 1 Address",
         Telephone = "1234567890"
     },
     new Supplier
     {
         SupplierId = 2,
         SupplierName = "Supplier 2",
         SupplierAddress = "Supplier 2 Address",
         Telephone = "0987654321"
     }
     // Add more suppliers as needed
 );

            base.OnModelCreating(modelBuilder);
        }

      
    }
}
