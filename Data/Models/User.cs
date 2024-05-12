using Microsoft.AspNetCore.Identity;

namespace UserProductAPI.Data.Models
{
    public class User: IdentityUser
    {
        public string Role { get; set; }
        public User() : base()
        {
            
        }
    }
}
