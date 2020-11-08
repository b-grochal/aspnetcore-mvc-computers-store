using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using ComputersStore.Data.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComputersStore.WebUI.Controllers
{
    [Authorize(Roles = ApplicationUserRoleDictionary.Admin)]
    public class ApplicationUsersController : Controller
    {
        #region Fields

        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly int applicationUserPerPage = 5;

        #endregion Fields

        #region Constructors

        public ApplicationUsersController(IApplicationUserBusinessService applicationUserBusinessService)
        {
            this.applicationUserBusinessService = applicationUserBusinessService;
        }

        #endregion Constrctors

        #region Actions

        // GET: ApplicationUsers/Customers
        public async Task<IActionResult> Customers(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var usersCollectionViewModel = await applicationUserBusinessService.GetApplicationUsersCollection(ApplicationUserRoleDictionary.Customer, firstName, lastName, email, phoneNumber, pageNumber, applicationUserPerPage);
            return View(usersCollectionViewModel);
        }

        // GET: ApplicationUsers/Admins
        public async Task<IActionResult> Admins(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var adminsCollectionViewModel = await applicationUserBusinessService.GetApplicationUsersCollection(ApplicationUserRoleDictionary.Admin, firstName, lastName, email, phoneNumber, pageNumber, applicationUserPerPage);
            return View(adminsCollectionViewModel);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string applicationUserId)
        {
            if (applicationUserId == null)
            {
                return NotFound();
            }

            var applicationUserViewModel = await applicationUserBusinessService.GetApplicationUserById(applicationUserId);
            if (applicationUserViewModel == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/ApplicationUsers/Modals/_DeleteApplicationUserModal.cshtml", applicationUserViewModel);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string applicationUserId)
        {
            await applicationUserBusinessService.DeleteApplicationUser(applicationUserId);
            return Json( new { success = true});
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var applicationUserViewModel = await applicationUserBusinessService.GetApplicationUserById(id);
            return View(applicationUserViewModel);
        }

        #endregion Actions
    }
}