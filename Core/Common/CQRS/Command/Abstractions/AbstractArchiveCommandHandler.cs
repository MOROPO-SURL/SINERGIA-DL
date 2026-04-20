using MapsterMapper;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Abstractions;

internal abstract class AbstractArchiveCommandHandler<TEntity, TId, TIdValue, TArchiveCommand> : MediatR.IRequestHandler<TArchiveCommand>
    where TEntity : class, IArchivableEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TArchiveCommand : IArchiveCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractArchiveCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TArchiveCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityQueryRepository.GetAsync(mapper.Map<TId>(request.Id!));

        entity.IsArchived = true;

        await entityCommandRepository.UpdateAsync(entity);

        return;
    }
}
