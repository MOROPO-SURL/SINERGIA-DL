using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Disable;

internal sealed class StrategicLineDisableCommandHandler : IRequestHandler<StrategicLineDisableCommand>
{
    private readonly IStrategicLineCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;

    public StrategicLineDisableCommandHandler(IStrategicLineCommandRepositoryPort entityCommandRepository, IStrategicLineQueryRepositoryPort entityQueryRepository)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task Handle(StrategicLineDisableCommand request, CancellationToken cancellationToken)
    {
        StrategicLine entity = await entityQueryRepository.GetAsync(new StrategicLineId(request.Id), new Domain.Aggretates.StrategicAxeAggregate.Values.StrategicAxeId(request.AxeId));

        entityCommandRepository.TrackChanges(entity);

        entity.IsEnabled = false;

        await entityCommandRepository.UpdateAsync(entity);
    }
}