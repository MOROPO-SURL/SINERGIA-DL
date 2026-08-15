using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Detail;

internal sealed class SocialSupportDemandDetailQueryHandler : 
    AbstractDetailQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandDetailQuery, SocialSupportDemandDetailDto>,
    IRequestHandler<SocialSupportDemandDetailQuery, SocialSupportDemandDetailDto>
{
    public SocialSupportDemandDetailQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityQueryRepository, mapper)
    {
    }
}