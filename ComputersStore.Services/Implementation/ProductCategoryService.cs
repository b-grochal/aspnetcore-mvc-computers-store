using ComputersStore.Data.Entities;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        #region Fields

        private readonly ApplicationDbContext applicationDbContext;

        #endregion Fields

        #region Constructors

        public ProductCategoryService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        #endregion Constructors

        #region Public methods

        public async Task<IEnumerable<ProductCategory>> GetProductCategoriesCollection()
        {
            return await applicationDbContext.ProductCategories.ToListAsync();
        }

        #endregion Public methods
    }
}
