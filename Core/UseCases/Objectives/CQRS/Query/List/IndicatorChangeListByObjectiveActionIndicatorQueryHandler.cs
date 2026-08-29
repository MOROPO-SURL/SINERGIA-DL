using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;

internal sealed class IndicatorChangeListByObjectiveActionIndicatorQueryHandler : IRequestHandler<IndicatorChangeListByObjectiveActionIndicatorQuery, IndicatorChangeDetailDto[]>
{
    private readonly IObjectiveActionIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListByObjectiveActionIndicatorQueryHandler(IObjectiveActionIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListByObjectiveActionIndicatorQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeListByObjectiveActionIndicator(new ObjectiveId(request.ObjectiveId), new ObjectiveActionId(request.ActionId), new ObjectiveActionIndicatorId(request.IndicatorId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}