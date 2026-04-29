using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.CQRS.Query.Paginate;

internal sealed class PublicPolicyPaginateQueryHandler : AbstractPaginateQueryHandler<PublicPolicy, PublicPolicyId, Guid, PublicPolicyPaginateQuery, PublicPolicyBasicDto>,
IRequestHandler<PublicPolicyPaginateQuery, PaginateQueryResultModel<PublicPolicyBasicDto>>
{
    public PublicPolicyPaginateQueryHandler(IPublicPolicyQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<PublicPolicy, object>> OrderExpression => entity => entity.PublishedAt;

    protected override bool IsOrderDescending => true;
}
