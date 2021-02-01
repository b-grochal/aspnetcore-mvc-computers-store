using ComputersStore.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Newsletter.Base
{
    public class NewsletterSignUpFormViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [IsTrue(ValidationFailMessage = "You have to accept terms of newsletter.")]
        public bool AreTermsOfNewsletterAccepted { get; set; }
    }
}
