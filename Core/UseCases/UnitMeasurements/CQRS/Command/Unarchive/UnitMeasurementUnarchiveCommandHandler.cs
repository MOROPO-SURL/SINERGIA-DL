using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Unarchive;

internal sealed class UnitMeasurementUnarchiveCommandHandler: AbstractUnarchiveCommandHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementUnarchiveCommand>,
IRequestHandler<UnitMeasurementUnarchiveCommand>
{
    public UnitMeasurementUnarchiveCommandHandler(IUnitMeasurementCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
