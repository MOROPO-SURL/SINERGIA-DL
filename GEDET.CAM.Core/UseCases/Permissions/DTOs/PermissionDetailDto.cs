using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Permissions.DTOs;

public record PermissionDetailDto(string Id, string? Family, string? Description) : IDetailDto;