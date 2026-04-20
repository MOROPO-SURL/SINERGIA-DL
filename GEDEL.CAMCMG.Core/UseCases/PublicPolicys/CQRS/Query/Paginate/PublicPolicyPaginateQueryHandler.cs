using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicys.CQRS.Query.Paginate;

internal sealed class PublicPolicyPaginateQueryHandler: AbstractPaginateQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyPaginateQuery, PublicPolicyBasicDto>,
IRequestHandler<PublicPolicyPaginateQuery, PaginateQueryResultModel<PublicPolicyBasicDto>>
{
    public PublicPolicyPaginateQueryHandler(IPublicPolicyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}
