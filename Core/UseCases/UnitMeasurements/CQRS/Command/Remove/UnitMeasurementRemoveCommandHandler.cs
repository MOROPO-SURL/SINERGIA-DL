using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Remove;

internal sealed class UnitMeasurementRemoveCommandHandler: AbstractRemoveCommandHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementRemoveCommand>, IRequestHandler<UnitMeasurementRemoveCommand>
{
    public UnitMeasurementRemoveCommandHandler(IUnitMeasurementCommandRepositoryPort entityCommandRepository, IUnitMeasurementQueryRepositoryPort entityQueryRepository, IMapper mapper)
        : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
