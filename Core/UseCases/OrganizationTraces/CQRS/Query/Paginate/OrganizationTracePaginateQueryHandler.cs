using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Models;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Paginate;

internal sealed class OrganizationTracePaginateQueryHandler :
    AbstractPaginateQueryHandler<OrganizationTrace, TraceId, long, OrganizationTracePaginateQuery, OrganizationTraceBasicDto>,
    IRequestHandler<OrganizationTracePaginateQuery, PaginateQueryResultModel<OrganizationTraceBasicDto>>
{
    public OrganizationTracePaginateQueryHandler(IOrganizationTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<OrganizationTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}