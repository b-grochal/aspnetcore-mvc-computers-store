using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputersStore.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShipAddress = table.Column<string>(nullable: true),
                    ShipCity = table.Column<string>(nullable: true),
                    ShipPostalCode = table.Column<string>(nullable: true),
                    ShipCountry = table.Column<string>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProductCategory = table.Column<int>(nullable: false),
                    NumberOfCores = table.Column<int>(nullable: true),
                    NumberOfThreads = table.Column<int>(nullable: true),
                    ClockSpeed = table.Column<string>(nullable: true),
                    TDP = table.Column<string>(nullable: true),
                    Socket = table.Column<string>(nullable: true),
                    Architecture = table.Column<string>(nullable: true),
                    ManufacturingProcess = table.Column<string>(nullable: true),
                    MemorySize = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    MemorySpeed = table.Column<string>(nullable: true),
                    MemoryBus = table.Column<string>(nullable: true),
                    Interface = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    RotationSpeed = table.Column<string>(nullable: true),
                    CacheSize = table.Column<string>(nullable: true),
                    HardDiskDrive_Interface = table.Column<string>(nullable: true),
                    FormFactor = table.Column<string>(nullable: true),
                    CpuSocket = table.Column<string>(nullable: true),
                    Chipset = table.Column<string>(nullable: true),
                    Motherboard_MemoryType = table.Column<string>(nullable: true),
                    MemoryChannel = table.Column<string>(nullable: true),
                    SataSupport = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Wattage = table.Column<string>(nullable: true),
                    RandomAccessMemory_Size = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    CasLatency = table.Column<string>(nullable: true),
                    SolidStateDrive_Capacity = table.Column<string>(nullable: true),
                    SolidStateDrive_Interface = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
