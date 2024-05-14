using Microsoft.AspNetCore.Authorization;

namespace UserProductAPI.Authorization
{
    public class RoleAuthorization : AuthorizationHandler<UserRole>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRole requirement)
        {
            var userRoleClaim = context.User.FindFirst(claim => claim.Type == "role")?.Value;

            if (userRoleClaim == null)
            {
                return Task.CompletedTask;
            }

            if (userRoleClaim == requirement.Role)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
