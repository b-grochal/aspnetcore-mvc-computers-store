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
using ComputersStore.Models.ViewModels.Newsletter;
using ComputersStore.Models.ViewModels.Emails;
using ComputersStore.EmailHelper.Service.Interface;

namespace ComputersStore.WebUI.Controllers
{
    public class NewslettersController : Controller
    {
        private readonly INewsletterBusinessService newsletterBusinessService;
        private readonly IEmailService emailMessagesService;
        private readonly int newslettersPerPage = 5;

        public NewslettersController(INewsletterBusinessService newsletterBusinessService, IEmailService emailMessagesService)
        {
            this.newsletterBusinessService = newsletterBusinessService;
            this.emailMessagesService = emailMessagesService;
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

            return PartialView("_DeleteNewsletterModalPartial", newsletter);
        }

        // POST: Newsletters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            await newsletterBusinessService.DeleteNewsletter(id);
            return RedirectToAction(nameof(Table));
        }

        // GET: Newsletter/SendNewsletter
        public IActionResult SendNewsletter()
        {
            return View();
        }

        //POST: Newsletters/SendNewsletter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendNewsletter(EmailMessageFormViewModel emailMessageFormViewModel)
        {
            if (ModelState.IsValid)
            {
                await SendNewsletterEmail(emailMessageFormViewModel);
                return RedirectToAction(nameof(SendNewsletterConfirmation));
            }
            return View(emailMessageFormViewModel);
        }

        [HttpGet]
        public IActionResult SendNewsletterConfirmation()
        {
            return View();
        }

        private async Task SendNewsletterEmail(EmailMessageFormViewModel emailMessageFormViewModel)
        {
            var newslettersEmailsCollection = await newsletterBusinessService.GetNewlettersEmailsCollection();
            await emailMessagesService.SendNewsletterEmail(newslettersEmailsCollection, emailMessageFormViewModel.Title, emailMessageFormViewModel.Content);
        }
    }
}
