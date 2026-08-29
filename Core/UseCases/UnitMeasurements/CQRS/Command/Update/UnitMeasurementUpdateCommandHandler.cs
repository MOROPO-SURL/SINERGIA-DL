using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Update;

internal sealed class UnitMeasurementUpdateCommandHandler: AbstractUpdateCommandHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementUpdateCommand, UnitMeasurementDetailDto>,
    IRequestHandler<UnitMeasurementUpdateCommand, UnitMeasurementDetailDto>
{
    public UnitMeasurementUpdateCommandHandler(IUnitMeasurementCommandRepositoryPort entityCommandRepository, IUnitMeasurementQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
