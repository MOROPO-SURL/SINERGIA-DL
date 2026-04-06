namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Ports.Manager;

internal interface IRoleRuntimeManagerPort
{
    void RememberRole(Core.UseCases.Roles.DTOs.RoleDetailDto role);

    Core.UseCases.Roles.DTOs.RoleDetailDto FindRoleById(Guid roleId);

    void ForguetRoleById(Guid roleId);

    Guid[] GetRoleIdsByPermission(string permission);
}
