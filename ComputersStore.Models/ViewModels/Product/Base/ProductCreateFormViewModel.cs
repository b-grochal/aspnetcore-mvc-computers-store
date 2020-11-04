using ComputersStore.Data.Entities;
using ComputersStore.Models.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product
{
    public abstract class ProductCreateFormViewModel
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
    
        [Required]
        [Display(Name="Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name="Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }
        
        [Required]
        [Display(Name="Image")]
        [MaxFileSize(50 * 1024)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile ImageFile { get; set; }
    }
}
