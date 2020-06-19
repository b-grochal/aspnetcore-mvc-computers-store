using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Services.Interfaces
{
    public interface INewsletterService
    {
        void CreateNewsletter(Newsletter newsletter);
    }
}
