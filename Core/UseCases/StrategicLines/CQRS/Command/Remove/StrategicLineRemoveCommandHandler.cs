using MediatR;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Remove;

internal sealed class StrategicLineRemoveCommandHandler : IRequestHandler<StrategicLineRemoveCommand>
{
    private readonly IStrategicLineCommandRepositoryPort entityCommandRepository;
    private readonly IStrategicLineQueryRepositoryPort entityQueryRepository;

    public StrategicLineRemoveCommandHandler(IStrategicLineQueryRepositoryPort entityQueryRepository, IStrategicLineCommandRepositoryPort entityCommandRepository)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
    }

    public async Task Handle(StrategicLineRemoveCommand request, CancellationToken cancellationToken)
    {
        StrategicLine entity = await entityQueryRepository.GetAsync(new StrategicLineId(request.Id), new Domain.Aggretates.StrategicAxeAggregate.Values.StrategicAxeId(request.AxeId));

        await entityCommandRepository.DeleteAsync(entity);
    }
}