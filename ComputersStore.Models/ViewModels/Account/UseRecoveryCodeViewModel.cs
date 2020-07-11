using System.ComponentModel.DataAnnotations;

namespace ComputersStore.Models.ViewModels.Account
{
    public class UseRecoveryCodeViewModel
    {
        [Required]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }
    }
}
