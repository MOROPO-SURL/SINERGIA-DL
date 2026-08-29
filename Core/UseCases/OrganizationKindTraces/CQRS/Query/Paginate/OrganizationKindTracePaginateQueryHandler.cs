using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Paginate;

internal sealed class OrganizationKindTracePaginateQueryHandler :
AbstractPaginateQueryHandler<OrganizationKindTrace, TraceId, long, OrganizationKindTracePaginateQuery, OrganizationKindTraceBasicDto>,
IRequestHandler<OrganizationKindTracePaginateQuery, PaginateQueryResultModel<OrganizationKindTraceBasicDto>>
{
    public OrganizationKindTracePaginateQueryHandler(IOrganizationKindTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<OrganizationKindTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}

