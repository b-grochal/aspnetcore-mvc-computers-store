using ComputersStore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public abstract class ProductDetailsViewModel
    {
        [Display(Name="Id")]
        public int ProductId { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name="Description")]
        public string Description { get; set; }

        [Display(Name="Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        public int ProductCategoryId { get; set; }

        [Display(Name="Category")]
        public string ProductCategoryName { get; set; }

        public string ImageDataUrl { get; set; }
    }
}
