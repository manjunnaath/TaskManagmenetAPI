using Microsoft.AspNetCore.Identity;

namespace TaskManagementAPI.Models
{
 
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }

}
