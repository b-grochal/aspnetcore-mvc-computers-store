using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputersStore.BusinessServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputersStore.WebUI.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly IApplicationUserBusinessService applicationUserBusinessService;
        private readonly int usersPerPage = 5;
        public ApplicationUsersController(IApplicationUserBusinessService applicationUserBusinessService)
        {
            this.applicationUserBusinessService = applicationUserBusinessService;
        }

        public async Task<IActionResult> Users(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var usersCollectionViewModel = await applicationUserBusinessService.GetUsersCollection(firstName, lastName, email, phoneNumber, pageNumber, usersPerPage);
            return View(usersCollectionViewModel);
        }

        public async Task<IActionResult> Admins(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var adminsCollectionViewModel = await applicationUserBusinessService.GetAdminsCollection(firstName, lastName, email, phoneNumber, pageNumber, usersPerPage);
            return View(adminsCollectionViewModel);
        }
    }
}