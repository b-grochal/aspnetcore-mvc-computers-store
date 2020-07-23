using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.ViewModels.ApplicationUser
{
    public class ApplicationUserViewModel
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
