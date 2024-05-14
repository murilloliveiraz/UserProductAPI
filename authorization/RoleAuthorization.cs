using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserProductAPI.Authorization
{
    public class RoleAuthorization : AuthorizationHandler<UserRole>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRole requirement)
        {
            var userRoleClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.Role);

            if (userRoleClaim == null || userRoleClaim.Value != requirement.Role)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (userRoleClaim.Value == requirement.Role)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
