using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlowerBouquets",
                columns: table => new
                {
                    FlowerBouquetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FlowerBouquetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    FlowerBouquetStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerBouquets", x => x.FlowerBouquetId);
                    table.ForeignKey(
                        name: "FK_FlowerBouquets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerBouquets_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FlowerBouquetId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.FlowerBouquetId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_FlowerBouquets_FlowerBouquetId",
                        column: x => x.FlowerBouquetId,
                        principalTable: "FlowerBouquets",
                        principalColumn: "FlowerBouquetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category 1 Description", "Category 1" },
                    { 2, "Category 2 Description", "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Birthday", "City", "Country", "CustomerName", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 1", "Country 1", "Customer 1", "customer1@example.com", "password1", 0 },
                    { 2, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 2", "Country 2", "Customer 2", "customer2@example.com", "password2", 0 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "SupplierAddress", "SupplierName", "Telephone" },
                values: new object[,]
                {
                    { 1, "Supplier 1 Address", "Supplier 1", "1234567890" },
                    { 2, "Supplier 2 Address", "Supplier 2", "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "FlowerBouquets",
                columns: new[] { "FlowerBouquetId", "CategoryId", "Description", "FlowerBouquetName", "FlowerBouquetStatus", "SupplierId", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Flower Bouquet 1 Description", "Flower Bouquet 1", (byte)1, 1, 10.99m, 50 },
                    { 2, 2, "Flower Bouquet 2 Description", "Flower Bouquet 2", (byte)1, 2, 12.99m, 30 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "OrderStatus", "ShippedDate", "Total" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 17, 21, 53, 5, 448, DateTimeKind.Local).AddTicks(7346), "Completed", new DateTime(2023, 6, 18, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(393), 100.00m },
                    { 2, 2, new DateTime(2023, 6, 17, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(1647), "Completed", new DateTime(2023, 6, 19, 21, 53, 5, 449, DateTimeKind.Local).AddTicks(1652), 150.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "FlowerBouquetId", "OrderId", "Discount", "Quantity", "UnitPrice" },
                values: new object[] { 1, 1, 0.0, 5, 10.99m });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "FlowerBouquetId", "OrderId", "Discount", "Quantity", "UnitPrice" },
                values: new object[] { 2, 1, 0.0, 3, 12.99m });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerBouquets_CategoryId",
                table: "FlowerBouquets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerBouquets_SupplierId",
                table: "FlowerBouquets",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FlowerBouquetId",
                table: "OrderDetails",
                column: "FlowerBouquetId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "FlowerBouquets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
