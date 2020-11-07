using ComputersStore.Models.SearchParams.ApplicationUser;
using ComputersStore.Models.ViewModels.ApplicationUser.Base;
using ComputersStore.Models.ViewModels.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ApplicationUser.Complex
{
    public class ApplicationUsersCollectionViewModel
    {
        public IEnumerable<ApplicationUserViewModel> applicationUsers { get; set; }
        public PaginationViewModel PaginationViewModel { get; set; }
        public ApplicationUsersTableSearchParams applicationUserSearchCriteria { get; set; }
    }
}
