using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.OrganizationTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Query.Detail;

internal sealed class OrganizationTraceDetailQueryHandler :
    AbstractDetailQueryHandler<OrganizationTrace, TraceId, long, OrganizationTraceDetailQuery, OrganizationTraceDetailDto>,
    IRequestHandler<OrganizationTraceDetailQuery, OrganizationTraceDetailDto>
{
    public OrganizationTraceDetailQueryHandler(IOrganizationTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}