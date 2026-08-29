using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Query.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Query.List;

internal sealed class StrategicAxeListQueryHandler :
    AbstractListQueryHandler<StrategicAxe, StrategicAxeId, int, StrategicAxeDetailDto, StrategicAxeListQuery>,
    IRequestHandler<StrategicAxeListQuery, StrategicAxeDetailDto[]>
{
    public StrategicAxeListQueryHandler(IStrategicAxeQueryRepositoryPort entityQueryRepository) : base(entityQueryRepository)
    {
    }
}