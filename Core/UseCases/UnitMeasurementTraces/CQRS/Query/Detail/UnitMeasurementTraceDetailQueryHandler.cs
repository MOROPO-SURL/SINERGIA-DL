using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurementTraces.CQRS.Query.Detail;

internal sealed class UnitMeasurementTraceDetailQueryHandler :
    AbstractDetailQueryHandler<UnitMeasurementTrace, TraceId, long, UnitMeasurementTraceDetailQuery, UnitMeasurementTraceDetailDto>,
    IRequestHandler<UnitMeasurementTraceDetailQuery, UnitMeasurementTraceDetailDto>
{
    public UnitMeasurementTraceDetailQueryHandler(IUnitMeasurementTraceQueryRepositoryPort userQueryRepository, IMapper mapper) : base(userQueryRepository, mapper)
    {
    }
}