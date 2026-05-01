using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UserTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.CQRS.Query.Detail;

internal sealed class UserTraceDetailQueryHandler :
    AbstractDetailQueryHandler<UserTrace, TraceId, long, UserTraceDetailQuery, UserTraceDetailDto>,
    IRequestHandler<UserTraceDetailQuery, UserTraceDetailDto>
{
    public UserTraceDetailQueryHandler(IUserTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}