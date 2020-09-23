using ComputersStore.Models.SearchCriteria.ApplicationUser;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ApplicationUser
{
    public class ApplicationUsersCollectionViewModel
    {
        public IEnumerable<ApplicationUserViewModel> applicationUsers { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public ApplicationUserSearchCriteria applicationUserSearchCriteria { get; set; }
    }
}
