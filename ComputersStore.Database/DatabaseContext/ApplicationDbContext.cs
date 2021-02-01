using System;
using System.Collections.Generic;
using System.Text;
using ComputersStore.Data.Entities;
using ComputersStore.Data.Dictionaries;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Database.EntityConfiguration;

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

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
