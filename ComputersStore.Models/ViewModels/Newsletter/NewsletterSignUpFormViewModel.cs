using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Newsletter
{
    public class NewsletterSignUpFormViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have to accept our terms of newsletter service.")]
        public bool AreTermsOfNewsletterAccepted { get; set; }
    }
}
