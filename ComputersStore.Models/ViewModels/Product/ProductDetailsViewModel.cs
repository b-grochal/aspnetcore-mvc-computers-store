using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public string ClockSpeed { get; set; }
        public string TDP { get; set; }
        public string Socket { get; set; }
        public string Architecture { get; set; }
        public string ManufacturingProcess { get; set; }
        public string MemorySize { get; set; }
        public string MemoryType { get; set; }
        public string MemorySpeed { get; set; }
        public string MemoryBus { get; set; }
        public string Interface { get; set; }
        public string Capacity { get; set; }
        public string RotationSpeed { get; set; }
        public string CacheSize { get; set; }
        public string FormFactor { get; set; }
        public string CpuSocket { get; set; }
        public string Chipset { get; set; }
        public string MemoryChannel { get; set; }
        public string SataSupport { get; set; }
        public string Size { get; set; }
        public string Wattage { get; set; }
        public string Type { get; set; }
        public string Speed { get; set; }
        public string CasLatency { get; set; }
        public string ImageDataUrl { get; set; }
    }
}
