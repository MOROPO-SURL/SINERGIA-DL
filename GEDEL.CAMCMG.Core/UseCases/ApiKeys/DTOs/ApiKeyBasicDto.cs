using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.ApiKeys.DTOs;

public record ApiKeyBasicDto(Guid Id, string Name, bool IsEnabled, DateTime ExpireAt) : IDto;