using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;

public record UserDetailDto(string Id, string Name, bool IsEnabled, bool HasFullAccess, bool IsPasswordChangeRequired, DateTime CreatedAt, DateTime? UpdatedAt, RoleDetailDto[] Roles, string? LastName = null) : IDetailDto;