using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.RoleTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.CQRS.Query.Detail;

internal sealed class RoleTraceDetailQueryHandler :
    AbstractDetailQueryHandler<RoleTrace, TraceId, long, RoleTraceDetailQuery, RoleTraceDetailDto>,
    IRequestHandler<RoleTraceDetailQuery, RoleTraceDetailDto>
{
    public RoleTraceDetailQueryHandler(IRoleTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}