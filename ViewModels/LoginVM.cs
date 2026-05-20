using System.ComponentModel.DataAnnotations;

namespace Practise.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UserNameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
