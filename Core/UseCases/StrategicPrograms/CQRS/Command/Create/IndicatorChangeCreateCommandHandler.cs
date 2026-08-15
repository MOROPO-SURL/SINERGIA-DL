using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

internal sealed class IndicatorChangeCreateCommandHandler : IRequestHandler<IndicatorChangeCreateCommand, IndicatorChangeDetailDto>
{
    private readonly IStrategicProgramCommandRepositoryPort entityCommandRepository;
    private readonly IMapper mapper;

    public IndicatorChangeCreateCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeCreateCommand request, CancellationToken cancellationToken)
    {
        ProgramActionIndicatorChange change = mapper.Map<ProgramActionIndicatorChange>(request);

        StrategicProgram entity = await entityCommandRepository.GetAsync(change.ProgramId);

        ProgramAction action = entity.Actions.Single(item => item.Id == change.ActionId);

        ProgramActionIndicator indicator = action.Indicators.Single(item => item.Id == change.IndicatorId);

        indicator.AddChange(change);

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ProgramActionIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}
