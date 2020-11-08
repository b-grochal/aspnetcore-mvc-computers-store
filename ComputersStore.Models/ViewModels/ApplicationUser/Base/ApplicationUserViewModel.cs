using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.ApplicationUser.Base
{
    public class ApplicationUserViewModel
    {
        [Display(Name="Id")]
        public string ApplicationUserId { get; set; }

        [Display(Name="First name")]
        public string FirstName { get; set; }

        [Display(Name="Last name")]
        public string LastName { get; set; }

        [Display(Name="Email")]
        public string Email { get; set; }

        [Display(Name="Phone number")]
        public string PhoneNumber { get; set; }
    }
}
