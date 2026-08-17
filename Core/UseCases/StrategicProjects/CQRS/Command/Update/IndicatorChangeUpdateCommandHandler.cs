using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

internal sealed class IndicatorChangeUpdateCommandHandler : MediatR.IRequestHandler<IndicatorChangeUpdateCommand, IndicatorChangeDetailDto>
{
    private readonly IStrategicProjectCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicProjectQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public IndicatorChangeUpdateCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IStrategicProjectQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeUpdateCommand request, CancellationToken cancellationToken)
    {
        StrategicProject entity = await entityQueryRepository.GetAsync(new Domain.Aggretates.StrategicProjectAggregate.Values.StrategicProjectId(request.ProjectId));

        ProjectIndicator indicator = entity.Indicators.Single(item => item.Id.Value == request.IndicatorId);

        ProjectIndicatorChange change = indicator.Changes.Single(item => item.Id.Value == request.Id);

        change.Amount = request.Amount;
        change.Context = request.Context;

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ProjectIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}