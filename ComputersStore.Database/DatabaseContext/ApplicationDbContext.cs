using System;
using System.Collections.Generic;
using System.Text;
using ComputersStore.Data.Entities;
using ComputersStore.Data.Dictionaries;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputersStore.Database.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CentralProcessingUnit> CentralProcessingUnits { get; set; }
        public DbSet<GraphicsProcessingUnit> GraphicsProcessingUnits { get; set; }
        public DbSet<HardDiskDrive> HardDiskDrives { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupplyUnit> PowerSupplyUnits { get; set; }
        public DbSet<RandomAccessMemory> RandomAccessMemories { get; set; }
        public DbSet<SolidStateDrive> SolidStateDrives { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

            modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductCategory>()
            .HasKey(p => p.ProductCategoryId);

            modelBuilder.Entity<OrderStatus>()
            .HasKey(p => p.OrderStatusId);

            modelBuilder.Entity<PaymentType>()
            .HasKey(p => p.PaymentTypeId);

            modelBuilder.Entity<OrderItem>()
            .HasKey(orderItem => new { orderItem.OrderId, orderItem.ProductId });

            modelBuilder.Entity<Product>().HasDiscriminator<int>("ProductCategoryDiscriminator")
                .HasValue<CentralProcessingUnit>(ProductCategoryDictionary.CPU)
                .HasValue<GraphicsProcessingUnit>(ProductCategoryDictionary.GPU)
                .HasValue<HardDiskDrive>(ProductCategoryDictionary.HDD)
                .HasValue<Motherboard>(ProductCategoryDictionary.Motherboard)
                .HasValue<PowerSupplyUnit>(ProductCategoryDictionary.PSU)
                .HasValue<RandomAccessMemory>(ProductCategoryDictionary.RAM)
                .HasValue<SolidStateDrive>(ProductCategoryDictionary.SSD);
        }
    }
}
