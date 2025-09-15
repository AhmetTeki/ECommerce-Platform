using Microsoft.AspNetCore.Identity;

namespace Multishop.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
    }
}
