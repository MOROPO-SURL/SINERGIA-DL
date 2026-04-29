using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractUnarchiveCommandHandler<TEntity, TId, TIdValue, TUnarchiveCommand> : MediatR.IRequestHandler<TUnarchiveCommand>
    where TEntity : class, IArchivableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TUnarchiveCommand : IUnarchiveCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractUnarchiveCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TUnarchiveCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityQueryRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entityCommandRepository.TrackChanges(entity);

        entity.IsArchived = false;

        await entityCommandRepository.UpdateAsync(entity);
    }
}
