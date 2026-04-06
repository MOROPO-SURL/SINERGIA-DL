using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;

public record UserBasicDto(string Id, string Name, bool IsIntegrityAssured, string? LastName, bool IsEnabled, bool HasFullAccess, DateTime CreatedAt) : IDto;