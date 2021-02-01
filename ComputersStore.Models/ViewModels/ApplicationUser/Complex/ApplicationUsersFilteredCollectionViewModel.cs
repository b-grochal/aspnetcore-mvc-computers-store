using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ApplicationUser.Complex
{
    public class ApplicationUsersFilteredCollectionViewModel
    {
        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
}
}
