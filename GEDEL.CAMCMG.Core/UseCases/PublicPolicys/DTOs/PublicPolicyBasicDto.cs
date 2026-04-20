using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.DTOs;

public record PublicPolicyBasicDto(Guid Id, string Title, string? Description) : IDto;

