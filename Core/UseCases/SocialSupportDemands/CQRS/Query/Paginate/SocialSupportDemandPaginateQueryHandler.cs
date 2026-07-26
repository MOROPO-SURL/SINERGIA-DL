using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.SocialSupportDemandAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.SocialSupportDemands.CQRS.Query.Paginate;

internal sealed class SocialSupportDemandPaginateQueryHandler : 
    AbstractPaginateQueryHandler<SocialSupportDemand, SocialSupportDemandId, Guid, SocialSupportDemandPaginateQuery, SocialSupportDemandBasicDto>,
    IRequestHandler<SocialSupportDemandPaginateQuery, PaginateQueryResultModel<SocialSupportDemandBasicDto>>
{
    public SocialSupportDemandPaginateQueryHandler(ISocialSupportDemandQueryRepositoryPort entityQueryRepository)
        : base(entityQueryRepository)
    {
    }
}