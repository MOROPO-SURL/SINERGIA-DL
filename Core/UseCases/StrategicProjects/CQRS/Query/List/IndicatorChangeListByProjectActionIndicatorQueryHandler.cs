using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

internal sealed class IndicatorChangeListByProjectActionIndicatorQueryHandler : IRequestHandler<IndicatorChangeListByProjectActionIndicatorQuery, IndicatorChangeDetailDto[]>
{
    private readonly IStrategicProjectIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListByProjectActionIndicatorQueryHandler(IStrategicProjectIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListByProjectActionIndicatorQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeListByProjectActionIndicator(new StrategicProjectId(request.ProjectId), new ProjectIndicatorId(request.IndicatorId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}