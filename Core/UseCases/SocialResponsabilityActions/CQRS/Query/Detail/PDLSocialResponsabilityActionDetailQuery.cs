using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialResponsabilityActionAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialResponsabilityActions.CQRS.Query.Detail;

public record PDLSocialResponsabilityActionDetailQuery(Guid Id) : IDetailQuery<SocialResponsabilityActionId, Guid, PDLSocialResponsabilityActionDetailDto>;