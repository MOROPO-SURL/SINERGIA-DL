using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Query.List;

internal sealed class StrategicAxeListQueryHandler :
    AbstractListQueryHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeDetailDto, StrategicAxeListQuery>,
    IRequestHandler<StrategicAxeListQuery, StrategicAxeDetailDto[]>
{
    public StrategicAxeListQueryHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}