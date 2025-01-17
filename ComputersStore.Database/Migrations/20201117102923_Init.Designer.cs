﻿// <auto-generated />
using System;
using ComputersStore.Database.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComputersStore.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201117102923_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComputersStore.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Newsletter", b =>
                {
                    b.Property<int>("NewsletterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsletterId");

                    b.ToTable("Newsletters");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ShipAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipPostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderStatusId");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsRecommended")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCategoryDiscriminator")
                        .HasColumnType("int");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");

                    b.HasDiscriminator<int>("ProductCategoryDiscriminator");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.CentralProcessingUnit", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("Architecture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClockSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturingProcess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCores")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfThreads")
                        .HasColumnType("int");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TDP")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.GraphicsProcessingUnit", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("Interface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoryBus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemorySize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemorySpeed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoryType")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.HardDiskDrive", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("CacheSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interface")
                        .HasColumnName("HardDiskDrive_Interface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RotationSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(6);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Motherboard", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CpuSocket")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormFactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoryChannel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoryType")
                        .HasColumnName("Motherboard_MemoryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SataSupport")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.PowerSupplyUnit", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wattage")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.RandomAccessMemory", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("CasLatency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnName("RandomAccessMemory_Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.SolidStateDrive", b =>
                {
                    b.HasBaseType("ComputersStore.Data.Entities.Product");

                    b.Property<string>("Capacity")
                        .HasColumnName("SolidStateDrive_Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interface")
                        .HasColumnName("SolidStateDrive_Interface")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue(7);
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Order", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Orders")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ComputersStore.Data.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputersStore.Data.Entities.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputersStore.Data.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComputersStore.Data.Entities.Product", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComputersStore.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ComputersStore.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
