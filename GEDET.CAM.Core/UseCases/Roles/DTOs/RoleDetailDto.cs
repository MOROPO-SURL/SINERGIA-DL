using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

public record RoleDetailDto(Guid Id, string Name, PermissionDetailModel[] Permissions, string? Description);