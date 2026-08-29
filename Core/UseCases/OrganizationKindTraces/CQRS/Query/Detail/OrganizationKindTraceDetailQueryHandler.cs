using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Detail;

internal sealed class OrganizationKindTraceDetailQueryHandler :
AbstractDetailQueryHandler<OrganizationKindTrace, TraceId, long, OrganizationKindTraceDetailQuery, OrganizationKindTraceDetailDto>,
IRequestHandler<OrganizationKindTraceDetailQuery, OrganizationKindTraceDetailDto>
{
    public OrganizationKindTraceDetailQueryHandler(IOrganizationKindTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
