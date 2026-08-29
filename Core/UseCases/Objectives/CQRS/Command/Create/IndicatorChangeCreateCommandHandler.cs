using MapsterMapper;
using MediatR;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Create;

internal sealed class IndicatorChangeCreateCommandHandler : IRequestHandler<IndicatorChangeCreateCommand, IndicatorChangeDetailDto>
{
    private readonly IObjectiveCommandRepositoryPort entityCommandRepository;
    private readonly IMapper mapper;

    public IndicatorChangeCreateCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeCreateCommand request, CancellationToken cancellationToken)
    {
        ObjectiveActionIndicatorChange change = mapper.Map<ObjectiveActionIndicatorChange>(request);

        Objective entity = await entityCommandRepository.GetAsync(change.ObjectiveId);

        ObjectiveAction action = entity.Actions.Single(item => item.Id == change.ActionId);

        ObjectiveActionIndicator indicator = action.Indicators.Single(item => item.Id == change.IndicatorId);

        indicator.AddChange(change);

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ObjectiveActionIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}
