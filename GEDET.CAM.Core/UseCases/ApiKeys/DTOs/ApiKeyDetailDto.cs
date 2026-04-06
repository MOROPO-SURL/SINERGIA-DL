using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;
using MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyDetailDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt, DateTime CreatedAt, PermissionDetailDto[] Permissions, DateTime? Updated = null, string? Host = null) : IDetailDto;