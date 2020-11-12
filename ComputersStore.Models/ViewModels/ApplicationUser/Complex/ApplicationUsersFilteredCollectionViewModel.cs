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
        public string FirstNameFilteringParameter { get; set; }
        public string LastNameFilteringParameter { get; set; }
        public string EmailFilteringParameter { get; set; }
        public string PhoneNumberFilteringParameter { get; set; }
}
}
