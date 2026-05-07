using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractDisableCommandHandler<TEntity, TId, TIdValue, TDisableCommand> : MediatR.IRequestHandler<TDisableCommand>
    where TEntity : class, IEnableableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TDisableCommand : IDisableCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IMapper mapper;

    protected AbstractDisableCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TDisableCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityCommandRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entity.IsEnabled = false;

        await entityCommandRepository.UpdateAsync(entity);
    }
}
