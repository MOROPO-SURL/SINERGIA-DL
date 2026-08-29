using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurementTraces.CQRS.Query.Detail;

internal sealed class UnitMeasurementTraceDetailQueryHandler :
    AbstractDetailQueryHandler<UnitMeasurementTrace, TraceId, long, UnitMeasurementTraceDetailQuery, UnitMeasurementTraceDetailDto>,
    IRequestHandler<UnitMeasurementTraceDetailQuery, UnitMeasurementTraceDetailDto>
{
    public UnitMeasurementTraceDetailQueryHandler(IUnitMeasurementTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}