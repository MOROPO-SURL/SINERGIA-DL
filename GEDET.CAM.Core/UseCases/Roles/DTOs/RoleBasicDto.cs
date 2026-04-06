using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

public record RoleBasicDto(Guid Id, string Name) : IDto;