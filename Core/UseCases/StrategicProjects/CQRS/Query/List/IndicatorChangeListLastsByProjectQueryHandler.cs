using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

internal sealed class IndicatorChangeListLastsByProjectQueryHandler : IRequestHandler<IndicatorChangeListLastsByProjectQuery, IndicatorChangeDetailDto[]>
{
    private readonly IStrategicProjectIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListLastsByProjectQueryHandler(IStrategicProjectIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListLastsByProjectQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeLastsByProject(new Domain.Aggretates.StrategicProjectAggregate.Values.StrategicProjectId(request.ProjectId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}