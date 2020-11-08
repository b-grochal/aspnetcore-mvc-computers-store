using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Product.Base
{
    public class NewProductCategoryFormViewModel
    {
        [Required]
        public int ProductCategoryId { get; set; }
    }
}
