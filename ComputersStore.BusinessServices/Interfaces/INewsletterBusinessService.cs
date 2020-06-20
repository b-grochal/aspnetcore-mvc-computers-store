using ComputersStore.Models.ViewModels.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface INewsletterBusinessService
    {
        void CreateNewsletter(NewsletterSignUpFormViewModel newsletterSignUpFormViewModel);
    }
}
