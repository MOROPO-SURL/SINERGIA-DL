using MapsterMapper;
using MOROPO.GEDET.CAM.Core.Common.Ports.Repository;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.GEDET.CAM.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.GEDET.CAM.Core.UseCases.Entitys.CQRS.Command.Remove;

internal abstract class AbstractRemoveCommandHandler<TEntity, TId, TIdValue, TRemoveCommand> : MediatR.IRequestHandler<TRemoveCommand>
    where TEntity : class, IEntity<TId, TIdValue>
    where TId : struct, IId<TIdValue>
    where TRemoveCommand: IRemoveCommand<TIdValue>
{
    private readonly IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository;
    private readonly IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository;
    private readonly IMapper mapper;

    protected AbstractRemoveCommandHandler(IEntityCommandRepositoryPort<TEntity, TId, TIdValue> entityCommandRepository, IEntityQueryRepositoryPort<TEntity, TId, TIdValue> entityQueryRepository, IMapper mapper)
    {
        this.entityCommandRepository = entityCommandRepository;
        this.entityQueryRepository = entityQueryRepository;
        this.mapper = mapper;
    }

    public async Task Handle(TRemoveCommand request, CancellationToken cancellationToken)
    {
        TEntity entity = await entityQueryRepository.GetAsync(mapper.Map<TId>(request.Id!));

        await entityCommandRepository.DeleteAsync(entity);

        return;
    }
}
