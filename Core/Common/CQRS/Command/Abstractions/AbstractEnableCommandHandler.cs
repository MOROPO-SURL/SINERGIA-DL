using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractEnableCommandHandler<TEntity, TId, TIdValue, TEnableCommand> : MediatR.IRequestHandler<TEnableCommand>
    where TEntity : class, IEnableableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TEnableCommand : IEnableCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractEnableCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TEnableCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityQueryRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entityCommandRepository.TrackChanges(entity);

        entity.IsEnabled = true;

        await entityCommandRepository.UpdateAsync(entity);
    }
}