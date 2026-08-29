using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;
using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Archive;

internal sealed class UnitMeasurementArchiveCommandHandler :
AbstractArchiveCommandHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementArchiveCommand>,
IRequestHandler<UnitMeasurementArchiveCommand>
{
    public UnitMeasurementArchiveCommandHandler(IUnitMeasurementCommandRepositoryPort entityCommandRepository, IMapper mapper) : base(entityCommandRepository, mapper)
    {
    }
}
