using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Paginate;

internal sealed class SocialSupportDemandPaginateQueryHandler : 
    AbstractPaginateQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandPaginateQuery, SocialSupportDemandBasicDto>,
    IRequestHandler<SocialSupportDemandPaginateQuery, PaginateQueryResultModel<SocialSupportDemandBasicDto>>
{
    public SocialSupportDemandPaginateQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository)
        : base(entityQueryRepository)
    {
    }
}