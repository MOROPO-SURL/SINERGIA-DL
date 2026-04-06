using MOROPO.GEDET.CAM.Core.Common.DTOs.Interfaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyBasicDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt) : IDto;