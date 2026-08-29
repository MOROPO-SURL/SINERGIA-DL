using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;

internal sealed class IndicatorChangeListLastsByObjectiveQueryHandler : IRequestHandler<IndicatorChangeListLastsByObjectiveQuery, IndicatorChangeDetailDto[]>
{
    private readonly IObjectiveActionIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListLastsByObjectiveQueryHandler(IObjectiveActionIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListLastsByObjectiveQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeLastsByObjective(new Domain.Aggretates.ObjectiveAggregate.Values.ObjectiveId(request.ObjectiveId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}