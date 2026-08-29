using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.DTOs;

public record UserBasicDto(string Id, string Name, bool IsIntegrityAssured, string? LastName, bool IsEnabled, bool HasFullAccess, DateTime CreatedAt) : IDto;