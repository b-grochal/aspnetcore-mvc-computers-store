﻿using ComputersStore.Models.ViewModels.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.BusinessServices.Interfaces
{
    public interface IApplicationUserBusinessService
    {
        ApplicationUserViewModel GetApplicationUser(string applicationUserId);
    }
}