using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Detail;

internal sealed class SocialSupportDemandDetailQueryHandler : 
    AbstractDetailQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandDetailQuery, SocialSupportDemandDetailDto>,
    IRequestHandler<SocialSupportDemandDetailQuery, SocialSupportDemandDetailDto>
{
    public SocialSupportDemandDetailQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityQueryRepository, mapper)
    {
    }
}