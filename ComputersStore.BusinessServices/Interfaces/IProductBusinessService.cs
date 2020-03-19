using ComputersStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IProductBusinessService
    {
        IEnumerable<ProductViewModel> GetProductsCollection();
    }
}
