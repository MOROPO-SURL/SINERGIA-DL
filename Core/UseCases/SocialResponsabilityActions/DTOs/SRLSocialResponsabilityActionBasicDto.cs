using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialResponsabilityActions.DTOs;

public record SRLSocialResponsabilityActionBasicDto(Guid Id, string Title, DateTime At) : IDto;