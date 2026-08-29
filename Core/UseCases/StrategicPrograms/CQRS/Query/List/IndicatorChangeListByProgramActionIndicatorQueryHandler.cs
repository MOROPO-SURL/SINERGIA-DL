using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

internal sealed class IndicatorChangeListByProgramActionIndicatorQueryHandler : IRequestHandler<IndicatorChangeListByProgramActionIndicatorQuery, IndicatorChangeDetailDto[]>
{
    private readonly IStrategicProgramActionIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListByProgramActionIndicatorQueryHandler(IStrategicProgramActionIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListByProgramActionIndicatorQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeListByProgramActionIndicator(new StrategicProgramId(request.ProgramId), new ProgramActionId(request.ActionId), new ProgramActionIndicatorId(request.IndicatorId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}