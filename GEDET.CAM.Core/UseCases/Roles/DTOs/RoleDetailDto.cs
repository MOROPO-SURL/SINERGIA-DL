using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

public record RoleDetailDto(Guid Id, string Name, PermissionDetailDto[] Permissions, string? Description) : IDetailDto;