using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Ports.Adapters.Manager;

internal sealed class InMemoryRoleRuntimeManagerPortAdapter : Ports.Manager.IRoleRuntimeManagerPort
{
    private readonly List<RoleDetailDto> roles;

    public InMemoryRoleRuntimeManagerPortAdapter()
    {
        roles = [];
    }

    public void RememberRole(RoleDetailDto role)
    {
        roles.Add(role);
    }
    public RoleDetailDto FindRoleById(Guid roleId)
    {
        return roles.First(item => item.Id == roleId);
    }

    public void ForguetRoleById(Guid roleId)
    {
        var target = roles.First(item => item.Id == roleId);

        roles.Remove(target);
    }

    public Guid[] GetRoleIdsByPermission(string permission)
    {
        var roleIds = new List<Guid>();

        foreach (var role in roles)
        {
            foreach (var bridge in role.Permissions)
            {
                if (bridge.Id == permission)
                {
                    roleIds.Add(role.Id);

                    break;
                }
            }
        };

        return [.. roleIds];
    }
}
