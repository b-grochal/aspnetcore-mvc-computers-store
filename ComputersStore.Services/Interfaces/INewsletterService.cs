﻿using ComputersStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComputersStore.Services.Interfaces
{
    public interface INewsletterService
    {
        Task CreateNewsletter(Newsletter newsletter);
        Task DeleteNewsletter(int newsletterId);
        Task<IEnumerable<Newsletter>> GetNewslettersCollection(int pageNumber, int pageSize);
        Task<Newsletter> GetNewsletter(int newsletterId);
        int GetNewslettersCollectionCount();
    }
}
