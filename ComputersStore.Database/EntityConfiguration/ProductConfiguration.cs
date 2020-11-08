using ComputersStore.Data.Dictionaries;
using ComputersStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Database.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasDiscriminator<int>("ProductCategoryDiscriminator")
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
