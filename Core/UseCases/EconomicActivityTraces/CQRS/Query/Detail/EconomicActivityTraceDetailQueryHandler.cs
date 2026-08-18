using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Detail;

internal sealed class EconomicActivityTraceDetailQueryHandler :
    AbstractDetailQueryHandler<EconomicActivityTrace, TraceId, long, EconomicActivityTraceDetailQuery, EconomicActivityTraceDetailDto>,
    IRequestHandler<EconomicActivityTraceDetailQuery, EconomicActivityTraceDetailDto>
{
    public EconomicActivityTraceDetailQueryHandler(IEconomicActivityTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}