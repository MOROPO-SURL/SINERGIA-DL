using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;

public record SocialSupportDemandBasicDto(Guid Id, string Title, DateTime? StartAt = null, DateTime? EndAt = null) : IDto;