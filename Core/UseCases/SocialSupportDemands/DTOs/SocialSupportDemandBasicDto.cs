using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;

public record SocialSupportDemandBasicDto(Guid Id, string Title, DateTime? StartAt = null, DateTime? EndAt = null) : IDto;