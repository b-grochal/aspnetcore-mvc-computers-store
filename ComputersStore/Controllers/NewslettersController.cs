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
using Microsoft.AspNetCore.Authorization;
using ComputersStore.Data.Dictionaries;
using ComputersStore.Models.ViewModels.Newsletter.Base;
using ComputersStore.Models.ViewModels.Emails.Base;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
    public class NewslettersController : Controller
    {
        #region Fields

        private readonly INewsletterBusinessService newsletterBusinessService;
        private readonly IEmailService emailService;
        private readonly int newslettersPerPage = 5;

        #endregion Fields

        #region Constructors

        public NewslettersController(INewsletterBusinessService newsletterBusinessService, IEmailService emailService)
        {
            this.newsletterBusinessService = newsletterBusinessService;
            this.emailService = emailService;
        }

        #endregion Constructors 

        #region Actions

        // GET: Newsletters/Table
        public async Task<IActionResult> Table(int? newsletterId, string newsletterEmail, int pageNumber = 1)
        {
            var newsletters = await newsletterBusinessService.GetNewslletersCollection(newsletterId, newsletterEmail, pageNumber, newslettersPerPage);
            return View(newsletters);
        }

        // GET: Newsletters/SignUpForNewsletter
        [AllowAnonymous]
        public IActionResult SignUpForNewsletter()
        {
            return View();
        }

        // POST: Newsletters/SignUpForNewsletter
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpForNewsletter(NewsletterSignUpFormViewModel newsletter)
        {
            if (ModelState.IsValid)
            {
                await newsletterBusinessService.CreateNewsletter(newsletter);
                return RedirectToAction(nameof(SignUpForNewsletterConfirmation));
            }
            return View(newsletter);
        }

        // GET: Newsletters/SignUpForNewsletterConfirmation
        [AllowAnonymous]
        public IActionResult SignUpForNewsletterConfirmation()
        {
            return View();
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

            return PartialView("~/Views/Newsletters/Modals/_DeleteNewsletterModal.cshtml", newsletter);
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

        // GET: Newsletter/SendNewsletterConfiration
        [HttpGet]
        public IActionResult SendNewsletterConfirmation()
        {
            return View();
        }

        #endregion Actions

        #region Helpers

        private async Task SendNewsletterEmail(EmailMessageFormViewModel emailMessageFormViewModel)
        {
            var newslettersEmailsCollection = await newsletterBusinessService.GetNewlettersEmailsCollection();
            await emailService.SendNewsletterEmail(newslettersEmailsCollection, emailMessageFormViewModel.Title, emailMessageFormViewModel.Content);
        }

        #endregion Helpers
    }
}
