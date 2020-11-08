using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Data.Entities;
using ComputersStore.Data;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Data.Dictionaries;
using ComputersStore.Models.ViewModels.Product;
using ComputersStore.Models.ViewModels.Other;
using Microsoft.AspNetCore.Authorization;
using ComputersStore.Models.ViewModels.Product.Base;
using ComputersStore.Models.ViewModels.Product.Complex;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
    public class ProductsController : Controller
    {
        #region Fields

        private readonly IProductBusinessService productBusinessService;
        private readonly IProductCategoryBusinessService productCategoryBusinessService;
        private readonly int productsPerPage = 5;

        #endregion Fields

        #region Constructors

        public ProductsController(IProductBusinessService productBusinessService, IProductCategoryBusinessService productCategoryBusinessService)
        {
            this.productBusinessService = productBusinessService;
            this.productCategoryBusinessService = productCategoryBusinessService;
        }

        #endregion Constructors

        #region Actions

        // GET: Products/List
        [AllowAnonymous]
        public async Task<ActionResult> List(int productCategoryId, int pageNumber = 1, string sortOrder = null)
        {
            var products = await productBusinessService.GetProductsCollection(productCategoryId, sortOrder, pageNumber, productsPerPage);
            var productsListViewModel = new ProductsListViewModel
            {
                Products = products,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = productsPerPage,
                    TotalItems = productBusinessService.GetProductsCollectionCount(productCategoryId),
                },
                ProductCategoryId = productCategoryId,
                SortOrder = sortOrder
            };
            return View(productsListViewModel);
        }

        // GET: Products/ChooseNewProductCategory
        public async Task<IActionResult> ChooseNewProductCategory()
        {
            await PassProductsCategoriesSelectListToView(null);
            return View();
        }

        // POST: Products/ChooseNewProductCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChooseNewProductCategory(NewProductCategoryFormViewModel productCategoryFormViewModel)
        {
            return RedirectToAction(nameof(Create), new { productCategoryId = productCategoryFormViewModel.ProductCategoryId });
        }

        // GET: Products/Table
        public async Task<IActionResult> Table(int? productCategoryId, string productName, bool? isRecommended, int pageNumber = 1)//TODO: W parametrach najpierw productName a później reszta
        {
            var productsTableViewModel = await productBusinessService.GetProductsCollectionForTable(productCategoryId, productName, isRecommended, pageNumber, productsPerPage);
            await PassProductsCategoriesSelectListToView(productCategoryId);
            return View(productsTableViewModel);
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetailsViewModel = await productBusinessService.GetProductDetails(id);
            if (productDetailsViewModel == null)
            {
                return NotFound();
            }
            return View(productDetailsViewModel);
        }

        // GET: Products/Create
        public IActionResult Create(int productCategoryId)
        {
            var newProductViewModel = productBusinessService.PrepareNewEmptyProduct(productCategoryId);
            return View(newProductViewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateFormViewModel newProductViewModel)
        {
            if (ModelState.IsValid)
            {
                await productBusinessService.CreateProduct(newProductViewModel);
                return RedirectToAction(nameof(List));
            }
            return View(newProductViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productEditFormViewModel = await productBusinessService.GetProductForUpdate(id);
            if (productEditFormViewModel == null)
            {
                return NotFound();
            }
            return View(productEditFormViewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditFormViewModel productsDetailsViewModel)
        {
            if (id != productsDetailsViewModel.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await productBusinessService.UpdateProduct(productsDetailsViewModel);
                return RedirectToAction(nameof(List));
            }
            return View(productsDetailsViewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productBusinessService.GetProduct(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/Products/Modals/_DeleteProductModal.cshtml", product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productBusinessService.DeleteProduct(id);
            return RedirectToAction(nameof(List));
        }

        // POST: Products/SearchProducts
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchProducts(string searchString)
        {
            var searchedProductsCollectionViewModel = await productBusinessService.GetSearchedProductsCollection(searchString);
            return View(searchedProductsCollectionViewModel);
        }

        #endregion Actions

        #region Helpers

        public async Task PassProductsCategoriesSelectListToView(int? productCategory)
        {
            var productCategories = await productCategoryBusinessService.GetProductsCategoriesCollection();
            ViewData["ProductsCategories"] = new SelectList(productCategories, "ProductCategoryId", "Name", productCategory);
        }

        #endregion Helpers
    }
}
