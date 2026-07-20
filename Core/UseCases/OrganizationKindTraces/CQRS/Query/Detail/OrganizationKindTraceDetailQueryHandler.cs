using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationKindTraces.CQRS.Query.Detail;

internal sealed class OrganizationKindTraceDetailQueryHandler :
AbstractDetailQueryHandler<OrganizationKindTrace, TraceId, long, OrganizationKindTraceDetailQuery, OrganizationKindTraceDetailDto>,
IRequestHandler<OrganizationKindTraceDetailQuery, OrganizationKindTraceDetailDto>
{
    public OrganizationKindTraceDetailQueryHandler(IOrganizationKindTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}
