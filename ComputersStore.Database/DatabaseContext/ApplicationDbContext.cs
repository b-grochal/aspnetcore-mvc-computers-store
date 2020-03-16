using System;
using System.Collections.Generic;
using System.Text;
using ComputersStore.Core.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputersStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CentralProcessingUnit> CentralProcessingUnits { get; set; }
        public DbSet<GraphicsProcessingUnit> GraphicsProcessingUnits { get; set; }
        public DbSet<HardDiskDrive> HardDiskDrives { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupplyUnit> PowerSupplyUnits { get; set; }
        public DbSet<RandomAccessMemory> RandomAccessMemories { get; set; }
        public DbSet<SolidStateDrive> SolidStateDrives { get; set; }

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

            modelBuilder.Entity<OrderItem>()
                .HasKey(orderItem => new { orderItem.OrderId, orderItem.ProductId });

            modelBuilder.Entity<Product>().HasDiscriminator<ProductCategory>("ProductCategory")
                .HasValue<CentralProcessingUnit>(ProductCategory.CPU)
                .HasValue<GraphicsProcessingUnit>(ProductCategory.GPU)
                .HasValue<HardDiskDrive>(ProductCategory.HDD)
                .HasValue<Motherboard>(ProductCategory.Motherboard)
                .HasValue<PowerSupplyUnit>(ProductCategory.PSU)
                .HasValue<RandomAccessMemory>(ProductCategory.RAM)
                .HasValue<SolidStateDrive>(ProductCategory.SSD);
        }

    }
}
