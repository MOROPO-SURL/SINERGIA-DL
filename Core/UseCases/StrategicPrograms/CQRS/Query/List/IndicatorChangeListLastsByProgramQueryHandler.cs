using Mapster;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.Ports.Repository;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

internal sealed class IndicatorChangeListLastsByProgramQueryHandler : IRequestHandler<IndicatorChangeListLastsByProgramQuery, IndicatorChangeDetailDto[]>
{
    private readonly IStrategicProgramActionIndicatorChangeQueryRepositoryPort entityQueryRepository;

    public IndicatorChangeListLastsByProgramQueryHandler(IStrategicProgramActionIndicatorChangeQueryRepositoryPort entityQueryRepository)
    {
        this.entityQueryRepository = entityQueryRepository;
    }

    public Task<IndicatorChangeDetailDto[]> Handle(IndicatorChangeListLastsByProgramQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(entityQueryRepository.GetIndicatorChangeLastsByProgram(new Domain.Aggretates.StrategicProgramAggregate.Values.StrategicProgramId(request.ProgramId)).Select(entity => entity.Adapt<IndicatorChangeDetailDto>()).ToArray());
    }
}