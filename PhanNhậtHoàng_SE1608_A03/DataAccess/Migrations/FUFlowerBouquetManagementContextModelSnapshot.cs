﻿// <auto-generated />
using System;
using BussinessObject.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(FUFlowerBouquetManagementContext))]
    partial class FUFlowerBouquetManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BussinessObject.DataAccess.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "Category 1 Description",
                            CategoryName = "Category 1"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "Category 2 Description",
                            CategoryName = "Category 2"
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Birthday = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "City 1",
                            Country = "Country 1",
                            CustomerName = "Customer 1",
                            Email = "customer1@example.com",
                            Password = "password1",
                            Role = 0
                        },
                        new
                        {
                            CustomerId = 2,
                            Birthday = new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "City 2",
                            Country = "Country 2",
                            CustomerName = "Customer 2",
                            Email = "customer2@example.com",
                            Password = "password2",
                            Role = 0
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.FlowerBouquet", b =>
                {
                    b.Property<int?>("FlowerBouquetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlowerBouquetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("FlowerBouquetStatus")
                        .HasColumnType("tinyint");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("FlowerBouquetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("FlowerBouquets");

                    b.HasData(
                        new
                        {
                            FlowerBouquetId = 1,
                            CategoryId = 1,
                            Description = "Flower Bouquet 1 Description",
                            FlowerBouquetName = "Flower Bouquet 1",
                            FlowerBouquetStatus = (byte)1,
                            SupplierId = 1,
                            UnitPrice = 10.99m,
                            UnitsInStock = 50
                        },
                        new
                        {
                            FlowerBouquetId = 2,
                            CategoryId = 2,
                            Description = "Flower Bouquet 2 Description",
                            FlowerBouquetName = "Flower Bouquet 2",
                            FlowerBouquetStatus = (byte)1,
                            SupplierId = 2,
                            UnitPrice = 12.99m,
                            UnitsInStock = 30
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Order", b =>
                {
                    b.Property<int?>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            OrderDate = new DateTime(2023, 6, 17, 21, 53, 5, 448, DateTimeKind.Local).AddTicks(7346),
                            OrderStatus = "Completed",
                            ShippedDate = new DateTime(2023, 6, 18, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(393),
                            Total = 100.00m
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            OrderDate = new DateTime(2023, 6, 17, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(1647),
                            OrderStatus = "Completed",
                            ShippedDate = new DateTime(2023, 6, 19, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(1652),
                            Total = 150.00m
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("FlowerBouquetId")
                        .HasColumnType("int");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "FlowerBouquetId");

                    b.HasIndex("FlowerBouquetId");

                    b.ToTable("OrderDetails");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            FlowerBouquetId = 1,
                            Discount = 0.0,
                            Quantity = 5,
                            UnitPrice = 10.99m
                        },
                        new
                        {
                            OrderId = 1,
                            FlowerBouquetId = 2,
                            Discount = 0.0,
                            Quantity = 3,
                            UnitPrice = 12.99m
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SupplierAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            SupplierAddress = "Supplier 1 Address",
                            SupplierName = "Supplier 1",
                            Telephone = "1234567890"
                        },
                        new
                        {
                            SupplierId = 2,
                            SupplierAddress = "Supplier 2 Address",
                            SupplierName = "Supplier 2",
                            Telephone = "0987654321"
                        });
                });

            modelBuilder.Entity("BussinessObject.DataAccess.FlowerBouquet", b =>
                {
                    b.HasOne("BussinessObject.DataAccess.Category", "Category")
                        .WithMany("FlowerBouquets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.DataAccess.Supplier", "Supplier")
                        .WithMany("FlowerBouquets")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Order", b =>
                {
                    b.HasOne("BussinessObject.DataAccess.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.OrderDetail", b =>
                {
                    b.HasOne("BussinessObject.DataAccess.FlowerBouquet", "FlowerBouquet")
                        .WithMany("OrderDetails")
                        .HasForeignKey("FlowerBouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObject.DataAccess.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlowerBouquet");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Category", b =>
                {
                    b.Navigation("FlowerBouquets");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.FlowerBouquet", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BussinessObject.DataAccess.Supplier", b =>
                {
                    b.Navigation("FlowerBouquets");
                });
#pragma warning restore 612, 618
        }
    }
}
