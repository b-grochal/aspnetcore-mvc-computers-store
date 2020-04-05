﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Models.ViewModels.Complex;
using ComputersStore.Models.ViewModels.Specific;
using ComputersStore.Models.ViewModels.Basic;

namespace ComputersStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductBusinessService productBusinessService;
        private readonly int productsPerPage = 5;

        public ProductsController(ApplicationDbContext context, IProductBusinessService productBusinessService)
        {
            _context = context;
            this.productBusinessService = productBusinessService;
        }

        public ActionResult List(ProductCategory productCategory = ProductCategory.CPU, int pageNumber = 1, string sortOrder = null)
        {
            var products = productBusinessService.GetProductsCollection(productCategory, sortOrder, pageNumber, productsPerPage);
            var productsListViewModel = new ProductsListViewModel
            {
                Products = products,
                PaginationViewModel = new PaginationViewModel
                {
                    CurrentPage = pageNumber,
                    ItemsPerPage = productsPerPage,
                    TotalItems = products.Count()
                },
                ProductCategory = productCategory,
                SortOrder = sortOrder
            };
            return View(productsListViewModel);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var productDetailsViewModel = productBusinessService.GetProduct(id);
            if (productDetailsViewModel == null)
            {
                return NotFound();
            }
            return View(productDetailsViewModel);
        }

        // GET: Products/Create
        public IActionResult Create(ProductCategory productCategory)
        {
            var newProductViewModel = new NewProductViewModel
            {
                ProductCategory = productCategory
            };
            return View(newProductViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NewProductViewModel newProductViewModel)
        {
            if (ModelState.IsValid)
            {
                productBusinessService.AddProduct(newProductViewModel);
                return RedirectToAction(nameof(List));
            }
            return View(newProductViewModel);
        }

        // GET: Products/Edit/5
        public  ActionResult Edit(int id)
        {
            var productDetailsViewModel = productBusinessService.GetProduct(id);
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
        public  IActionResult Edit(int id, ProductDetailsViewModel productsDetailsViewModel)
        {
            if (id != productsDetailsViewModel.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                productBusinessService.UpdateProduct(productsDetailsViewModel);
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

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
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
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}