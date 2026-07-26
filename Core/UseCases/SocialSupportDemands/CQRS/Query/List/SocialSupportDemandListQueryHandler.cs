using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.List;

internal sealed class SocialSupportDemandListQueryHandler :
    AbstractListQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandDetailDto, SocialSupportDemandListQuery>,
    IRequestHandler<SocialSupportDemandListQuery, SocialSupportDemandDetailDto[]>
{
    public SocialSupportDemandListQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}