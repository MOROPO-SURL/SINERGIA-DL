using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UnitMeasurementAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Query.Detail;

internal sealed class UnitMeasurementDetailQueryHandler: AbstractDetailQueryHandler<UnitMeasurement, UnitMeasurementId, Guid, UnitMeasurementDetailQuery, UnitMeasurementDetailDto>,
    IRequestHandler<UnitMeasurementDetailQuery, UnitMeasurementDetailDto>
{
    public UnitMeasurementDetailQueryHandler(IUnitMeasurementQueryRepositoryPort unitMeasurementQueryRepository, IMapper mapper) : base(unitMeasurementQueryRepository, mapper)
    { 
    }
}
