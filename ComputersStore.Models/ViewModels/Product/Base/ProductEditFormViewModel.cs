﻿using ComputersStore.Data.Entities;
using ComputersStore.Models.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Base
{
    public abstract class ProductEditFormViewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name="Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name="Price")]
        public decimal Price { get; set; }

        public int ProductCategoryId { get; set; }

        [Required]
        [Display(Name = "Is recommended")]
        public bool IsRecommended { get; set; }

        [Required]
        [Display(Name="Update image?")]
        public bool IsImageUpdated { get; set; }

        [RequiredIfTrue(nameof(IsImageUpdated), ErrorMessage="New image is required.")]
        [MaxFileSize(50 * 1024)]
        [AllowedExtensions(new string[] { ".jpg" })]
        public IFormFile NewImageFile { get; set; }

        public string OldImage { get; set; }
    }
}
