using MapsterMapper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Update;

internal sealed class IndicatorChangeUpdateCommandHandler : MediatR.IRequestHandler<IndicatorChangeUpdateCommand, IndicatorChangeDetailDto>
{
    private readonly IObjectiveCommandRepositoryPort entityCommandRepository;
    private readonly IObjectiveQueryRepositoryPort entityQueryRepository;
    private readonly IMapper mapper;

    public IndicatorChangeUpdateCommandHandler(IObjectiveCommandRepositoryPort entityCommandRepository, IObjectiveQueryRepositoryPort entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task<IndicatorChangeDetailDto> Handle(IndicatorChangeUpdateCommand request, CancellationToken cancellationToken)
    {
        Objective entity = await entityQueryRepository.GetAsync(new Domain.Aggretates.ObjectiveAggregate.Values.ObjectiveId(request.ObjectiveId));

        ObjectiveAction action = entity.Actions.Single(item => item.Id.Value == request.ActionId);

        ObjectiveActionIndicator indicator = action.Indicators.Single(item => item.Id.Value == request.IndicatorId);

        ObjectiveActionIndicatorChange change = indicator.Changes.Single(item => item.Id.Value == request.Id);

        change.Amount = request.Amount;
        change.Context = request.Context;

        await entityCommandRepository.UpdateAsync(entity);

        return mapper.Map<ObjectiveActionIndicatorChange, IndicatorChangeDetailDto>(change);
    }
}