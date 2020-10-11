using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputersStore.Models.ViewModels.Emails
{
    public class EmailMessageFormViewModel
    {
        [Required]
        [Display(Name = "Title of email")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Content of email")]
        public string Content { get; set; }
    }
}
