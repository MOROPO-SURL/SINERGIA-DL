using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Detail;

public record SocialSupportDemandDetailQuery(Guid Id) : IDetailQuery<SocialSupportDemandId, Guid, DTOs.SocialSupportDemandDetailDto>;