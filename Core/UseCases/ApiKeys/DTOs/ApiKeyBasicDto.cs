using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyBasicDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt) : IDto;