using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;

internal sealed class UnitMeasurementDetailQueryHandler: AbstractDetailQueryHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementDetailQuery, UnitMeasurementDetailDto>,
    IRequestHandler<UnitMeasurementDetailQuery, UnitMeasurementDetailDto>
{
    public UnitMeasurementDetailQueryHandler(IUnitMeasurementQueryRepositoryPort unitMeasurementQueryRepository, IMapper mapper) : base(unitMeasurementQueryRepository, mapper)
    { 
    }
}
