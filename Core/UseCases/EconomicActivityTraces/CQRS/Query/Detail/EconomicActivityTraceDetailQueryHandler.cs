using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.EconomicActivityTraces.CQRS.Query.Detail;

internal sealed class EconomicActivityTraceDetailQueryHandler :
    AbstractDetailQueryHandler<EconomicActivityTrace, TraceId, long, EconomicActivityTraceDetailQuery, EconomicActivityTraceDetailDto>,
    IRequestHandler<EconomicActivityTraceDetailQuery, EconomicActivityTraceDetailDto>
{
    public EconomicActivityTraceDetailQueryHandler(IEconomicActivityTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}