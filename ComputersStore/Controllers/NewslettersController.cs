using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComputersStore.Core.Data;
using ComputersStore.Data;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Database.DatabaseContext;
using ComputersStore.Models.ViewModels.Newsletter;

namespace ComputersStore.WebUI.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly INewsletterBusinessService newsletterBusinessService;
        private readonly int newslettersPerPage = 5;

        public NewslettersController(INewsletterBusinessService newsletterBusinessService)
        {
            this.newsletterBusinessService = newsletterBusinessService;
        }

        public async Task<IActionResult> Table(int? newsletterId, string newsletterEmail, int pageNumber = 1)
        {
            var newsletters = await newsletterBusinessService.GetNewslletersCollection(newsletterId, newsletterEmail, pageNumber, newslettersPerPage);
            return View(newsletters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsletterSignUpFormViewModel newsletter)
        {
            if (ModelState.IsValid)
            {
                await newsletterBusinessService.CreateNewsletter(newsletter);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Newsletters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsletter = await newsletterBusinessService.GetNewsletter(id.Value);
            if (newsletter == null)
            {
                return NotFound();
            }

            return View(newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            await newsletterBusinessService.DeleteNewsletter(id);
            return RedirectToAction(nameof(Table));
        }
    }
}
