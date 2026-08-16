using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

internal sealed class IndicatorChangeCreateCommandHandler : IRequestHandler<IndicatorChangeCreateCommand, IndicatorChangeDetailDto>
{
    private readonly IStrategicProjectCommandRepositoryPort entityCommandRepository;
    private readonly IMapper mapper;

    public IndicatorChangeCreateCommandHandler(IStrategicProjectCommandRepositoryPort entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeCreateCommand request, CancellationToken cancellationToken)
    {
        ProjectIndicatorChange change = mapper.Map<ProjectIndicatorChange>(request);

        StrategicProject entity = await entityCommandRepository.GetAsync(change.ProjectId);

        ProjectIndicator indicator = entity.Indicators.Single(item => item.Id == change.IndicatorId);

        indicator.AddChange(change);

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ProjectIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}