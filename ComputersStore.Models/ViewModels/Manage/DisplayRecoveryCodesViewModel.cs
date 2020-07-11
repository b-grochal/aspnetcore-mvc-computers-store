using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputersStore.Models.ViewModels.Manage
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }

    }
}
