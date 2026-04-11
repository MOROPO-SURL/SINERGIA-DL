using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Constants;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Extensions;

public static class ClaimPrincipalExtensions
{
    public static bool IsAuthorized(this System.Security.Claims.ClaimsPrincipal self, string permission, HttpContext httpContext)
    {
        if (self.HasClaim(claim => claim.Type.Equals(AuthorizationConstants.ClaimTypes.FULL_ACCESS))) return true;

        var roleIds = self.Claims.Where(item => item.Type == System.Security.Claims.ClaimsIdentity.DefaultRoleClaimType).Select(item => item.Value).ToArray();

        foreach (var roleId in roleIds)
        {
            var permissions = httpContext.RequestServices.GetService<Ports.Manager.IRoleRuntimeManagerPort>()!.FindRoleById(Guid.Parse(roleId)).Permissions.Select(item => item.Id).ToArray();

            foreach (var item in permissions)
            {
                if (item == permission) return true;
            }
        }

        return false;
    }
}
