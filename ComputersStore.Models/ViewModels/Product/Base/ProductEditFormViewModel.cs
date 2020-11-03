using ComputersStore.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public abstract class ProductEditFormViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCategoryName { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsImageUpdated { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
