using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Roles.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Ports.Manager;

internal interface IRoleRuntimeManagerPort
{
    void RememberRole(RoleDetailDto role);

    RoleDetailDto FindRoleById(Guid roleId);

    void ForguetRoleById(Guid roleId);

    Guid[] GetRoleIdsByPermission(string permission);
}
