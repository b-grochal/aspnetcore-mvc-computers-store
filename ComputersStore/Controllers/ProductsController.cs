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

namespace ComputersStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBusinessService productBusinessService;
        private readonly IProductCategoryBusinessService productCategoryBusinessService;
        private readonly int productsPerPage = 5;

        public ProductsController(IProductBusinessService productBusinessService, IProductCategoryBusinessService productCategoryBusinessService)
        {
            this.productBusinessService = productBusinessService;
            this.productCategoryBusinessService = productCategoryBusinessService;
        }

        public async Task<ActionResult> List(int productCategoryId = ProductCategoryDictionary.CPU, int pageNumber = 1, string sortOrder = null)
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

        public async Task<IActionResult> ChooseNewProductCategory()
        {
            await PassProductsCategoriesSelectListToView(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChooseNewProductCategory(ProductCategoryFormViewModel productCategoryFormViewModel)
        {
            return RedirectToAction(nameof(Create), new { productCategoryId = productCategoryFormViewModel.ProductCategoryId });
        }

        public async Task<IActionResult> Table(int? productCategoryId, string productName, bool? isRecommended, int pageNumber = 1)//TODO: W parametrach najpierw productName a później reszta
        {
            var productsTableViewModel = await productBusinessService.GetProductsCollectionForTable(productCategoryId, productName, isRecommended, pageNumber, productsPerPage);
            await PassProductsCategoriesSelectListToView(productCategoryId);
            return View(productsTableViewModel);
        }

        // GET: Products/Details/5
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
        public IActionResult Create(int productCategoryId = ProductCategoryDictionary.CPU)
        {
            var newProductViewModel = new ProductCreateFormViewModel
            {
                ProductCategoryId = productCategoryId
            };
            return View(newProductViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind("Name,Description,Price,NumberOfCores,NumberOfThreads,ClockSpeed,TDP,Socket,Architecture,ManufacturingProcess,ImageFile,ProductCategory")]
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
            var productDetailsViewModel = await productBusinessService.GetProductEditFormData(id);
            if (productDetailsViewModel == null)
            {
                return NotFound();
            }
            return View(productDetailsViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productBusinessService.DeleteProduct(id);
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchProducts(string searchString)
        {
            var searchedProductsCollectionViewModel = await productBusinessService.GetSearchedProductsCollection(searchString);
            return View(searchedProductsCollectionViewModel);
        }

        public async Task PassProductsCategoriesSelectListToView(int? productCategory)
        {
            var productCategories = await productCategoryBusinessService.GetProductsCategoriesCollection();
            ViewData["ProductsCategories"] = new SelectList(productCategories, "ProductCategoryId", "Name", productCategory);
        }
    }
}
