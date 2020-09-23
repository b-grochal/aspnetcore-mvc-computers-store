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

        public IActionResult Users(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var usersCollectionViewModel = applicationUserBusinessService.GetUsersCollection(firstName, lastName, email, phoneNumber, pageNumber, usersPerPage);
            return View(usersCollectionViewModel);
        }

        public IActionResult Admins(string firstName, string lastName, string email, string phoneNumber, int pageNumber = 1)
        {
            var adminsCollectionViewModel = applicationUserBusinessService.GetAdminsCollection(firstName, lastName, email, phoneNumber, pageNumber, usersPerPage);
            return View(adminsCollectionViewModel);
        }
    }
}