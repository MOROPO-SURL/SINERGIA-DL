using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;
using System.Linq.Expressions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationTraces.CQRS.Query.List;

internal sealed class OrganizationTraceListQueryHandler :
    AbstractListQueryHandler<OrganizationTrace, TraceId, long, OrganizationTraceDetailDto, OrganizationTraceListQuery>,
    IRequestHandler<OrganizationTraceListQuery, OrganizationTraceDetailDto[]>
{
    public OrganizationTraceListQueryHandler(IOrganizationTraceQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }

    protected override Expression<Func<OrganizationTrace, object>> OrderExpression => entity => entity.CreatedAt;

    protected override bool IsOrderDescending => true;
}