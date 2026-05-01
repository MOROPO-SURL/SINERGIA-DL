using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Paginate;

internal sealed class RoleTracePaginateQueryHandler :
    AbstractPaginateQueryHandler<RoleTrace, TraceId, long, RoleTracePaginateQuery, RoleTraceBasicDto>,
    IRequestHandler<RoleTracePaginateQuery, PaginateQueryResultModel<RoleTraceBasicDto>>
{
    public RoleTracePaginateQueryHandler(IRoleTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<RoleTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}