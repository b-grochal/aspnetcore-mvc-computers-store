using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsRecommended { get; set; }
        public string ImageDataUrl { get; set; }
        public object ProductCategoryName { get; internal set; }
    }
}
