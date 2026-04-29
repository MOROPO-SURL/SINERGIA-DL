using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Enable;

internal sealed class StrategicLineEnableCommandHandler : IRequestHandler<StrategicLineEnableCommand>
{
    private readonly IStrategicLineCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;

    public StrategicLineEnableCommandHandler(IStrategicLineCommandRepositoryPort entityCommandRepository, IStrategicLineQueryRepositoryPort entityQueryRepository)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task Handle(StrategicLineEnableCommand request, CancellationToken cancellationToken)
    {
        StrategicLine entity = await entityQueryRepository.GetAsync(new StrategicLineId(request.Id), new Domain.Aggretates.StrategicAxeAggregate.Values.StrategicAxeId(request.AxeId));

        entityCommandRepository.TrackChanges(entity);

        entity.IsEnabled = true;

        await entityCommandRepository.UpdateAsync(entity);
    }
}