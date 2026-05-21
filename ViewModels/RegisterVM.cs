using System.ComponentModel.DataAnnotations;

namespace Practise.ViewModels
{
    public class RegisterVM
    {
        public string? FullName { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
