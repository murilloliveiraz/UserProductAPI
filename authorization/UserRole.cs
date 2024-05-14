using Microsoft.AspNetCore.Authorization;

namespace UserProductAPI.Authorization
{
    public class UserRole : IAuthorizationRequirement
    {
        public string Role { get; set;}

        public UserRole(string role)
        {
            Role = role;
        }
    }
}
