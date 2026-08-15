using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

internal sealed class IndicatorChangeUpdateCommandHandler : MediatR.IRequestHandler<IndicatorChangeUpdateCommand, IndicatorChangeDetailDto>
{
    private readonly IStrategicProgramCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicProgramQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public IndicatorChangeUpdateCommandHandler(IStrategicProgramCommandRepositoryPort entityCommandRepository, IStrategicProgramQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeUpdateCommand request, CancellationToken cancellationToken)
    {
        StrategicProgram entity = await entityQueryRepository.GetAsync(new Domain.Aggretates.StrategicProgramAggregate.Values.StrategicProgramId(request.ProgramId));

        ProgramAction action = entity.Actions.Single(item => item.Id.Value == request.ActionId);

        ProgramActionIndicator indicator = action.Indicators.Single(item => item.Id.Value == request.IndicatorId);

        ProgramActionIndicatorChange change = indicator.Changes.Single(item => item.Id.Value == request.Id);

        change.Amount = request.Amount;
        change.Context = request.Context;

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ProgramActionIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}