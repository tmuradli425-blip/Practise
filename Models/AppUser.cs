using Microsoft.AspNetCore.Identity;

namespace Practise.Models
{
    public class AppUser:IdentityUser
    {
        public string? FullName { get; set; }
    }
}
