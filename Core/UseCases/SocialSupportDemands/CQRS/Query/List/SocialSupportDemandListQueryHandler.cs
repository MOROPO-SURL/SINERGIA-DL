using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Query.List;

internal sealed class SocialSupportDemandListQueryHandler :
    AbstractListQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandDetailDto, SocialSupportDemandListQuery>,
    IRequestHandler<SocialSupportDemandListQuery, SocialSupportDemandDetailDto[]>
{
    public SocialSupportDemandListQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}