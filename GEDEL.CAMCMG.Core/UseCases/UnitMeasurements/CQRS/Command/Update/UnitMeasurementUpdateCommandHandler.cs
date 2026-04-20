using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Command.Update;

internal sealed class UnitMeasurementUpdateCommandHandler: AbstractUpdateCommandHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementUpdateCommand, UnitMeasurementDetailDto>,
    IRequestHandler<UnitMeasurementUpdateCommand, UnitMeasurementDetailDto>
{
    public UnitMeasurementUpdateCommandHandler(IUnitMeasurementCommandRepositoryPort entityCommandRepository, IUnitMeasurementQueryRepositoryPort entityQueryRepository, IMapper mapper)
    : base(entityCommandRepository, entityQueryRepository, mapper)
    {
    }
}
