using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;

public record UserBasicDto(string Id, string Name, bool IsIntegrityAssured, string? LastName, bool IsEnabled, bool HasFullAccess, DateTime CreatedAt) : IDto;